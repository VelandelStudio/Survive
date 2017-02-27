using UnityEngine;

public class ItemActivable : MonoBehaviour {
	
	[SerializeField]
	private String textToDisplay = "Press E to activate";

    public String DisplayTextActivableItem()
    {
        return textToDisplay;
    }
    
    public virtual void onActivation() {
        
    }
}