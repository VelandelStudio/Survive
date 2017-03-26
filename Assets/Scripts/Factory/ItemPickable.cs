using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ItemPickable : MonoBehaviour {

    [SerializeField]
    private string textToDisplay = "Press E to pick up";
	[SerializeField]
    private float timeToDestroy;
	
    private Rigidbody rb;
    private Collider colliderItem;
	
	public int ID = -1;
	private float leavingTime;
	
	private void Awake() {
		leavingTime = timeToDestroy;
		rb = GetComponent<Rigidbody>();
		colliderItem = GetComponent<Collider>();
		rb.isKinematic = false;
		rb.useGravity = true;
		colliderItem.isTrigger = false;
	} 
	
 	protected virtual void Start() {
		Invoke("DestroyItem",timeToDestroy);
	}
	
	protected virtual void Update() {
		leavingTime -= Time.deltaTime;
	}
	
    public string DisplayTextPickableItem() {
        return textToDisplay;
    }

    public virtual void onPickup() {
		CancelInvoke();
		if(Inventory.Instance.AddItem(ID,leavingTime, timeToDestroy))
			Destroy(gameObject);
		else {
			Debug.Log("Inventory is full");
		}
    }
	
	public void RespawnFromInventory(float leavingTime) {
		CancelInvoke();
		this.leavingTime = leavingTime;
		Invoke("DestroyItem",leavingTime);
	}
	
	private void DestroyItem() {
		Destroy(gameObject);
	}
	
	private void OnCollisionEnter(Collision collision){
		if(collision.gameObject.layer == LayerMask.NameToLayer("Floor")) {
			rb.isKinematic = true;
			rb.useGravity = false;
			colliderItem.isTrigger = true;
		}
	}
}	