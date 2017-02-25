using UnityEngine;
using UnityEngine.UI;

public class ItemsActivable : MonoBehaviour {
    [SerializeField]
    private Text textCentral;

    protected virtual void Start()
    {
        textCentral.text = "";
        textCentral.enabled = false;
    }

    public void displayTextActivableIem()
    {
        textCentral.text = "Press E to activate";
        textCentral.enabled = true;
    }
}
