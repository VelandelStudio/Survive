using UnityEngine;
using System.Collections.Generic;

public class InventoryItemConsommable : InventoryItemBase {
	
	protected float duration;
	protected float leavingTime;
	protected List<float> DurationsInInventory; 
	
	protected override void Start() {
		duration = GetComponent<ItemPickable>().GetTimeToDestroy();
		leavingTime = duration;
		DurationsInInventory = new List<float>();
		base.Start();
	}
	
	protected override void Update() {
		if(positionInInventory != 1) {
			for(int i = 0; i < DurationsInInventory.Count; i++) {
				DurationsInInventory[i] -= Time.deltaTime;
				if(DurationsInInventory[i] <= 0) {
					InventoryManager.Instance.PerishItemConsommableFromInventory(gameObject);
					DurationsInInventory.RemoveAt(i);
				}
			}
			DurationsInInventory.Sort();
		}
		
		leavingTime -= Time.deltaTime;
		base.Update();	
	}

	public void StackConsommable(float leavingTime){
		DurationsInInventory.Add(leavingTime);
	}
	
	public void RemoveStack() {
		DurationsInInventory.RemoveAt(0);
	}
	
	public float GetLeavingTimeInStack() {
		return DurationsInInventory[0];
	}
	
	public float GetLeavingTime() {
		return leavingTime;
	}
}	