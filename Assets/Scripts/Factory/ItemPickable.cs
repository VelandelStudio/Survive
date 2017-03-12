using UnityEngine;
using System;

public class ItemPickable : MonoBehaviour {

    [SerializeField]
    private string textToDisplay = "Press E to pick up";
	[SerializeField]
    private float timeToDestroy;
	[SerializeField]
	private GameObject objectsToDisable;

 	protected virtual void Start() {
		Invoke("DestroyItem",timeToDestroy);
	}

    public string DisplayTextPickableItem() {
        return textToDisplay;
    }

    public virtual void onPickup() {
		CancelInvoke();
		if(InventoryManager.Instance.AddItemToInventory(gameObject)) {
			objectsToDisable.SetActive(false);
			this.enabled = false;
		}
    }

	public virtual void RespawnMe() {
		if(objectsToDisable != null)
			objectsToDisable.SetActive(true);

		Invoke("DestroyItem",timeToDestroy);
	}
	
	///TODO : A ajouter dans uen future version avec des objets perissables
	public virtual void RespawnMe(float newDuration) {
		CancelInvoke();
		timeToDestroy = newDuration;
		Invoke("DestroyItem",timeToDestroy);
	}
	
	///TODO : A ajouter dans uen future version avec des objets perissables
	public virtual float GetTimeToDestroy() {
		return timeToDestroy;
	}

	public GameObject GetObjectsToDisable() {
		return objectsToDisable;
	}
	
	protected virtual void DestroyItem() {
		Destroy(gameObject);
	}
}	