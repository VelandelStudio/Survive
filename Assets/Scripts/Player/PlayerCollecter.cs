using UnityEngine;
using UnityEngine.UI;

public class PlayerCollecter : MonoBehaviour {
	
	[SerializeField]
	private Text textCollecter;
    [SerializeField]
    private float portee;
    [SerializeField]
    private Camera fpsCam;
    private RaycastHit hitPoint;

	private void Start() {
		textCollecter.enabled = false;
	}
	
	private void Update() {
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * portee, Color.red);
		if(Physics.Raycast(lineOrigin, fpsCam.transform.forward * portee, out hitPoint)) {
            ItemPickable itemPickable = hitPoint.collider.GetComponent<ItemPickable>();
			ItemActivable itemActivable = hitPoint.collider.GetComponent<ItemActivable>();

            if (itemPickable != null)
            {
                textCollecter.text = itemPickable.DisplayTextPickableItem();
                textCollecter.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                    itemPickable.onPickup();
            }

            else if (itemActivable != null)
            {
                textCollecter.text = itemActivable.DisplayTextActivableItem();
                textCollecter.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                    itemActivable.onActivation();
            }
            else if (textCollecter.enabled)
                textCollecter.enabled = false;
		}
        else
            textCollecter.enabled = false;
    }
}