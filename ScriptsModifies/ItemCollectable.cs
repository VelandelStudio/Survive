using UnityEngine;

public class ItemsPickable : MonoBehaviour {

    [SerializeField]
    private String textToDisplay = "Press E to pick up";


    public String DisplayTextPickableItem()
    {
        return textToDisplay;
    }
    
    public virtual void onPickup() {
        
    }
}