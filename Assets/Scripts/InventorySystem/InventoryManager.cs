using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {
	[SerializeField]
	private GameObject inventoryCanvas;
	[SerializeField]
	private GameObject playerFoot;
	[SerializeField]
	private int inventorySize;
	[SerializeField]
	private GameObject slotPrefab;
	
	List<GameObject> objInInventory = new List<GameObject>();
	List<Slot> slotsInventory = new List<Slot>();
	List<int> nbObjInInventory = new List<int>();

	private static InventoryManager instance; 
	public static InventoryManager Instance {get {return instance;}}

	private void Awake() {
		if(instance != null && instance != this)
			Destroy(this.gameObject);
		else
			instance = this;
		
		for(int i = 0; i < inventorySize; i++) {
			GameObject slotInstance = Instantiate(slotPrefab);
			slotInstance.transform.SetParent(inventoryCanvas.transform);
			slotInstance.transform.position = new Vector3(i*64+64,0,0);
			objInInventory.Add(slotInstance);
			slotsInventory.Add(slotInstance.GetComponent<Slot>());
		}
	}

	public GameObject GetPlayerFoot() {
		return playerFoot;
	}
	
	public bool AddItemToInventory(GameObject newObj) {
		Slot slotToAddObject = LookForInventorySlot(newObj);
		Debug.Log(slotToAddObject);
		if(slotToAddObject == null)
			return false;
		
		slotToAddObject.AddGameObjectToSlot(newObj);	
		return true;
	}
	
	public void RemoveItemFromInventory(GameObject newObj) {
		
		int posToRemove = LookForSlotToRemove(newObj);
		
		GameObject instanceToSpawn = Instantiate(newObj);
		instanceToSpawn.name = newObj.name;
		
		GameObject itemMaterial = newObj.GetComponent<ItemPickable>().GetObjectsToDisable();
		
		RemoveElementFromSlot(newObj, posToRemove);
		InstantiateObjectInWorld(newObj, instanceToSpawn, itemMaterial);
	}
	
	public void PerishItemConsommableFromInventory(GameObject newObj) {
		int posToRemove = LookForSlotToRemove(newObj);
		RemoveElementFromSlot(newObj, posToRemove);
	}
	
	private Slot LookForInventorySlot(GameObject newObj) {		
		int alternativePos = -1;
		for(int i = 0; i < slotsInventory.Count; i++) {
			if(alternativePos == -1 && slotsInventory[i].slotIsEmpty) {
				alternativePos = i;
			}
			
			if(slotsInventory[i].objectStored != null && slotsInventory[i].objectStored.name == newObj.name) 
				return slotsInventory[i];
		}
		
		if(alternativePos != -1)
			return slotsInventory[alternativePos];
		
		return null;
	}
	
	private int LookForSlotToRemove(GameObject newObj) {
	/*	InventoryItemBase itemBase = newObj.GetComponent<InventoryItemBase>();
		
		int posToRemove = -1;
		for(int i = 0; i < objInInventory.Count; i++) {
			if(objInInventory[i] == null)
				continue;
			
			if(objInInventory[i].name == newObj.name && itemBase.GetPositionInInventory() == i)
				posToRemove = i;
		}
		return posToRemove;*/
		return 0;
	}

	private void RemoveElementFromSlot(GameObject newObj, int posToRemove) {

		if(nbObjInInventory[posToRemove] <= 1) {
			objInInventory[posToRemove] = null;
			nbObjInInventory[posToRemove] = 0;
			Destroy(newObj);
		}
		else
			nbObjInInventory[posToRemove]--;
	}
	
	private void InstantiateObjectInWorld(GameObject newObj, GameObject instanceToSpawn, GameObject itemMaterial) {
		Vector3 itemSizeFitter = new Vector3(itemMaterial.transform.lossyScale.x/2, itemMaterial.transform.lossyScale.y/2, itemMaterial.transform.lossyScale.z/2);
		ItemPickable itemPickable = instanceToSpawn.GetComponent<ItemPickable>();
		itemPickable.enabled = true;
		instanceToSpawn.transform.SetParent(null);
		GameObject instanceMaterial = instanceToSpawn.GetComponent<ItemPickable>().GetObjectsToDisable();
		instanceMaterial.transform.position = playerFoot.transform.position + itemSizeFitter;
		instanceMaterial.transform.rotation = playerFoot.transform.rotation;
		
		itemPickable.RespawnMe();
		
		InventoryItemConsommable itemConsommable = newObj.GetComponent<InventoryItemConsommable>();
		Debug.Log(itemConsommable.GetLeavingTimeInStack());
		
		if(itemConsommable != null) {
			itemPickable.RespawnMe(itemConsommable.GetLeavingTimeInStack());
			itemConsommable.RemoveStack();
		}
	}
}