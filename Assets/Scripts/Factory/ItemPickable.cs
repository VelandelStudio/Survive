using UnityEngine;

public class ItemPickable : MonoBehaviour {

    [SerializeField]
    private string textToDisplay = "Press E to pick up";


    public string DisplayTextPickableItem() {
        return textToDisplay;
    }
    
    public virtual void onPickup() {
        
    }
}