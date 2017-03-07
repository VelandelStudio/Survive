using UnityEngine;

public class ItemPickable : MonoBehaviour {

    [SerializeField]
    private string textToDisplay = "Press E to pick up";
	[SerializeField]
    private float TimeToDestroy;
	
	protected virtual void Start() {
		Invoke("DestroyItem",TimeToDestroy);
	}
	
    public string DisplayTextPickableItem() {
        return textToDisplay;
    }
    
    public virtual void onPickup() {
		CancelInvoke();
        DestroyItem();
    }
	
	protected virtual void DestroyItem() {
		Destroy(gameObject);
	}        
}	