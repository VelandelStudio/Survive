using UnityEngine;
using UnityEngine.UI;

public class DebuffDisplayer : MonoBehavior {
	[SerializeField]
	private Image debuffImage;
	[SerializeField]
	private Text textDuration;
	[SerializedField]
	private Text textEffect;
	[SerializedField]
	private TimedBuffer debuff;

	private Ray ray;
	private RaycastHit hit;
	
	private void Start() {
		debuffImage.enabled = true;
		
		textDuration.text = debuff.GetLeavingTime().toString;
		textDuration.enabled = true;
		
		textEffect.enabled = false;
	}
	
	private void Update() {
		textDuration.text = debuff.GetLeavingTime().toString;
		
		if(!Cursor.visible)
			return;
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
			if(hit.collider = this.collider) {
				textEffect.text = debuff.GetTextToDisplay;
				text.enabled = true;
			}
			else
				text.enabled = false;
		}
		text.enabled = false;
	}
}