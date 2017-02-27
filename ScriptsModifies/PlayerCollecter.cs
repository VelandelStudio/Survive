using UnityEngine;
using UnityEngine.UI;

public class PlayerCollecter : MonoBehavior {
	
	[SerializeField]
	private Text textCollecter;

	private void Start() {
		textCollecter.enabled = false;
	}
	
	private void Update() {	
		if(Physics.Raycast()) { //Raycast a courte distance
			ItemsPickable itemsPickable = hitPoint.collider.getComponent<ItemsPickable>();
			ItemsActivable itemsActivable = hitPoint.collider.getComponent<ItemsActivable>();

			if(itemsPickable != null) {
				textCollecter.text = DisplayTextPickableItem();
				text.enabled = true;
				
				if(Input.getGey(KeyCode.E)
					itemsPickable.onPickup();
			}

			else if(itemsActivable != null) {
				textCollecter.text = DisplayTextActivableItem();
				text.enabled = true;
				
				if(Input.getGey(KeyCode.E)
					itemsActivable.onActivation();
			}

		}
		else
			if(text.enabled)
				text.enabled = false;
	}
}