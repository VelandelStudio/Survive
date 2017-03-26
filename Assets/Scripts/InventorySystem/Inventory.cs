using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;
    [SerializeField]
    private GameObject slotPanel;
    [SerializeField]
    private GameObject inventorySlot;
    [SerializeField]
    private GameObject inventoryItem;
    [SerializeField]
    private int slotAmount;
    [SerializeField]
	private Transform player;

    private ItemDatabase database;
	private Tooltip tooltip;
	
    public List<Item> items = new List<Item>();
	[HideInInspector]
    public List<GameObject> slots = new List<GameObject>();

	private static Inventory instance; 
	public static Inventory Instance {get {return instance;}}

	private void Awake() {
		if(instance != null && instance != this)
			Destroy(this.gameObject);
		else
			instance = this;
		
		tooltip = GetComponent<Tooltip>();
	}
	
    private void Start()
    {
        database = GetComponent<ItemDatabase>();
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<Slot>().slotID = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }

    public bool AddItem(int ID, float leavingTime, float timeToDestroy) {
		
        Item itemToAdd = database.FetchItemById(ID);
		if(itemToAdd.Stackable) {
			GameObject slot = CheckIfInInventory(itemToAdd);
			if(slot != null) {
				incrementSlotStackSize(slot,itemToAdd);
				if(itemToAdd.Perishable) {
					ItemData data = slot.transform.GetChild(0).GetComponent<ItemData>();	
					data.perishDuration.Add(leavingTime);
					data.perishDuration.Sort();
				}
				return true;
			}
		}

		for(int i = 0; i < items.Count; i++) {
			if(items[i].ID == -1)
			{
				items[i] = itemToAdd;
				GameObject itemObj = Instantiate(inventoryItem);
				itemObj.transform.SetParent(slots[i].transform);
				itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
				itemObj.transform.localPosition = Vector3.zero;
				itemObj.name = itemToAdd.Title;
				ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();	
				data.item = itemToAdd;
				data.slotID = i;
				
				if(itemToAdd.Stackable)
					incrementSlotStackSize(slots[i],itemToAdd);
				
				if(itemToAdd.Perishable) {
					data.timeToDestroy = timeToDestroy;
					data.perishDuration = new List<float>();
					data.perishDuration.Add(leavingTime);
					data.fillerImage.enabled = true;
					data.fillerBackground.enabled = true;
				}
				return true;
			}
		}
		return false;
	}
	
	// Cette méthode est appelée pour la destruction des objets et non le drop on floor.
	// Elle survient lorsqu'un objet perishable a atteint son temps max et est détruit par exemple.
	public void DestroyItem(ItemData data) {
		Item item = data.item;
		if(!item.Stackable) {
			CleanSlot(data.slotID);
			Destroy(data.gameObject);
			return;
		}
		
		data.stackSize --;
		data.transform.GetComponentInChildren<Text>().text = data.stackSize.ToString();
		if(data.stackSize <= 0) {
			tooltip.DeActivate();
			CleanSlot(data.slotID);
			Destroy(data.gameObject);
			return;
		}
		
		if(item.Perishable) {
			data.perishDuration.RemoveAt(0);
		}
	}
	
	// Cette méthode est appelée lorsqu'on un objet est sorti de l'inventaire et est placé dans le monde.
	// Elle survient lorsqu'un objet est jetté depuis l'inventaire par un joueur qui n'en a pas/plus besoin.
	public void RemoveItem(ItemData data) {
		ProperlyInstatiate(data);
		CleanSlot(data.slotID);
		Destroy(data.gameObject);	
	}
	
	private GameObject CheckIfInInventory(Item item) {
		for(int i = 0; i < items.Count; i++) {
			if(items[i].ID == item.ID)
				return slots[i];
		}
		return null;
	}
	
	private void incrementSlotStackSize(GameObject slot, Item item) {
		ItemData data = slot.transform.GetChild(0).GetComponent<ItemData>();
		data.stackSize ++;
		data.transform.GetComponentInChildren<Text>().text = data.stackSize.ToString();
	}
	
	private void CleanSlot(int index) {
		items[index] = new Item();
	}
	
	private void ProperlyInstatiate(ItemData data) {
		Item item = data.item;		
		GameObject obj = item.gameObject;
		int index = 0;
		do {
			GameObject instanceObj = Instantiate(obj);
			instanceObj.name = obj.name;
			instanceObj.transform.position = player.position;
			if(item.Perishable)
				instanceObj.GetComponent<ItemPickable>().RespawnFromInventory(data.perishDuration[index]);
			index ++;
		} while (index < data.stackSize);
	}
}