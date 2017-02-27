using UnityEngine;
using UnityEngine.UI;

public class ItemsPickable : MonoBehaviour {

    [SerializeField]
    private Text textCentral;

    protected virtual void Start()
    {
        textCentral.text = "";
        textCentral.enabled = false;
    }

    public void DisplayTextActivableItem()
    {
        textCentral.text = "Press E to pick up";
        textCentral.enabled = true;
    }
    
    public virtual void onPickup() {
        
    }
}
