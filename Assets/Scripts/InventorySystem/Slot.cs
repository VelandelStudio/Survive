using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IDropHandler {
		
	public int slotID;
	
	public void OnDrop(PointerEventData eventData) {
		ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
		if(Inventory.Instance.items[slotID].ID == -1) {
			Inventory.Instance.items[droppedItem.slotID] = new Item();
			Inventory.Instance.items[slotID] = droppedItem.item;
			droppedItem.slotID = this.slotID;
		}
		else if(droppedItem.slotID != slotID)
			SwappItems(droppedItem);
	}
	
	private void SwappItems(ItemData droppedItem) {
		Transform item = this.transform.GetChild(0);
		item.GetComponent<ItemData>().slotID = droppedItem.slotID;
		item.transform.SetParent(Inventory.Instance.slots[droppedItem.slotID].transform);
		item.transform.position = Inventory.Instance.slots[droppedItem.slotID].transform.position;
		
		droppedItem.slotID = this.slotID;
		droppedItem.transform.SetParent(this.transform);
		droppedItem.transform.position = this.transform.position;
		
		Inventory.Instance.items[droppedItem.slotID] = item.GetComponent<ItemData>().item;
		Inventory.Instance.items[this.slotID] = droppedItem.item;
	}
}
