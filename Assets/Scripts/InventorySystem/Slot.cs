using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Slot : MonoBehaviour {
	
	public bool slotIsEmpty = true;
	public GameObject objectStored;
	
	public Image objectIcon;
	public int stackSize; 
	public List<float> perishItemTimeList;
	
	private bool mouseHover;
	
	public void AddGameObjectToSlot(GameObject obj) {
		if(slotIsEmpty) {
			slotIsEmpty = false; 
			objectStored = obj;
			objectIcon.sprite = obj.GetComponentInChildren<Image>().sprite;
		}
		
		if(obj.GetComponent<InventoryItemConsommable>())
			HandleAddingConsommable(obj);
		else
			HandleAddingBase(obj);
	}

	private void start() {
		objectStored = null;
		slotIsEmpty = true;
		stackSize = 0;
		perishItemTimeList = new List<float>();
	}	

	private void Update() {
		if(objectStored == null)
			return;
		
		if(objectStored.GetComponent<InventoryItemConsommable>())
			HandleUpdateConsommable();
		
		if(mouseHover && Input.GetKeyDown(KeyCode.Delete))
			HandleRemovingByThrow(InventoryManager.Instance.GetPlayerFoot());
	}

#region Adding Functions
	private void HandleAddingBase(GameObject obj) {
		stackSize++;
	}

	private void HandleAddingConsommable(GameObject obj) {
		InventoryItemConsommable invCons = obj.GetComponent<InventoryItemConsommable>();
		stackSize++;
		perishItemTimeList.Add(invCons.GetLeavingTime());
		perishItemTimeList.Sort();
	}
#endregion

#region Updating Functions
	private void HandleUpdateConsommable() {
		for(int i = perishItemTimeList.Count -1 ; i >= 0; i--) {
			perishItemTimeList[i] -= Time.deltaTime;
			if(perishItemTimeList[i] <= 0) {
				perishItemTimeList.RemoveAt(i);
				stackSize--;
			}
		}		
	}
#endregion

#region Removing Functions 
	private void HandleRemovingByThrow(GameObject playerFoot) {

		GameObject instanceToSpawn = Instantiate(objectStored);
		instanceToSpawn.name = objectStored.name;

		GameObject instanceMaterial = instanceToSpawn.GetComponent<ItemPickable>().GetObjectsToDisable();
		Vector3 itemSizeFitter = new Vector3(instanceMaterial.transform.lossyScale.x/2, instanceMaterial.transform.lossyScale.y/2, instanceMaterial.transform.lossyScale.z/2);

		ItemPickable itemPickable = instanceToSpawn.GetComponent<ItemPickable>();
		itemPickable.enabled = true;
		instanceToSpawn.transform.SetParent(null);
		instanceMaterial.transform.position = playerFoot.transform.position + itemSizeFitter;
		instanceMaterial.transform.rotation = playerFoot.transform.rotation;

		InventoryItemConsommable itemConsommable = objectStored.GetComponent<InventoryItemConsommable>();

		if(itemConsommable != null) {
			itemPickable.RespawnMe(itemConsommable.GetLeavingTimeInStack());
			perishItemTimeList.RemoveAt(0);
		}
		else
			itemPickable.RespawnMe();
	}

	private void HandleRemovingByUse() {
		///TODO Voir comment Appeler l'utilisation depuis le manager;
	}

	private void decrementStackSize() {
		if(stackSize <= 1) {
			slotIsEmpty = true;
			stackSize = 0;
			Destroy(objectStored);
		}
		else
			stackSize--;
	}
#endregion	

#region Getters and Setters
#endregion

	public void SetMouseHovering(bool b) {
		mouseHover = b;
	}
}