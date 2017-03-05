using UnityEngine;
using UnityEngine.UI;

public class DebuffDisplayer : MonoBehaviour {
	[SerializeField]
	private Text textDuration;
	[SerializeField]
	private Text textInfo;
	[SerializeField]
	private Image imageDebuff;
	[SerializeField]
	private Image imageFiller;
	
	private Ray ray;
	private RaycastHit hit;
	private float duration;
	private float leavingTime;

    private void Update() {
		imageFiller.fillAmount = (duration-leavingTime) /duration;
		
		///TODO Trouver une facon de raycast sur de l'UI.
		//Regarder du coté de Graphic raycast;
		if(!Cursor.visible)
			return;				
	}
	
	public void SetInitialDuration(float duration) {
		this.duration = duration;
		leavingTime = duration;
		textDuration.text = duration.ToString();
	}
	
	public void UpdateDisplayer(float leavingTime) {
		this.leavingTime = leavingTime;
		textDuration.text = ((int)(leavingTime+0.5)).ToString();
	}
	
	public void SetInfoTextToDisplayer(string str) {
		textInfo.text = str;
	}
	
	public void SetUpImageDebuff(Image image) {
        imageDebuff.sprite = image.sprite;
    }
}