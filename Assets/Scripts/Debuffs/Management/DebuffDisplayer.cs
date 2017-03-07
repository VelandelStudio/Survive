using UnityEngine;
using UnityEngine.UI;

public class DebuffDisplayer : MonoBehaviour {
	[SerializeField]
	private Text textDuration;
	[SerializeField]
	private GameObject textPanel;
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
	private bool mouseHover = false;
	
	private void Start() {
		textPanel.SetActive(false);
	}
	
    private void Update() {
		if(duration.ToString() == "Infinity")
			imageFiller.fillAmount = 0;
		else
			imageFiller.fillAmount = (duration-leavingTime) /duration;

		if(!Cursor.visible)
			return;	
		
		if(mouseHover) {
			textPanel.SetActive(true);
			textPanel.transform.position = Input.mousePosition + new Vector3(15,-10,0);	
		}
		else
			textPanel.SetActive(false);
	}
	
	public void Initialize(Image image, float duration, string description) {
		imageDebuff.sprite = image.sprite;
		
		this.duration = duration;
		leavingTime = duration;
		textDuration.text = duration.ToString();
		if(textDuration.text == "Infinity")
			textDuration.enabled = false;
		
		textInfo.text = description;
	}
		
	public void Modify(Image image, string description) {
		imageDebuff.sprite = image.sprite;		
		textInfo.text = description;
	}
	
	public void UpdateDisplayer(float leavingTime) {
		this.leavingTime = leavingTime;
		textDuration.text = ((int)(leavingTime+0.5)).ToString();
	}
	
	public void DisplayText() { 
		mouseHover = true;
	}
	
	public void CancelText() { 
		mouseHover = false;
	}
}