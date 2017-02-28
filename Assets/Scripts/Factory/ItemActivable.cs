using UnityEngine;

public class ItemActivable : MonoBehaviour {
	
	[SerializeField]
	private string textToDisplay = "Press E to activate";

    public virtual string DisplayTextActivableItem() {
        return textToDisplay;
    }
    
    public virtual void onActivation() {
        
    }
}