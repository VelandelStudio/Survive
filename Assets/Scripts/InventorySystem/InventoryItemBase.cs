using UnityEngine;

public class InventoryItemBase : MonoBehaviour {
		
	protected int positionInInventory;
	
	public virtual string TextToDisplay() {
		return ("Null Text Base " + gameObject.name);
	}
	
	protected virtual void Start() {
		positionInInventory = -1;
	}
	
	protected virtual void Update() {}
	
	protected virtual void ThrowItem() {
		InventoryManager.Instance.RemoveItemFromInventory(gameObject);
	} 
}