using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

	private ItemData data;
	private Item item;
	private string displayText;
	private string timer;
	[SerializeField]
	private GameObject tooltip;
	
	private void Start() {
		tooltip.SetActive(false);
	}
	
	private void Update() {
		if(tooltip.activeSelf){
			tooltip.transform.position = Input.mousePosition;
			if(data != null && item.Perishable) {
				timer = "\n<color=#F2F2F2>" + TimeHelper.ConvertFloatToTimer(data.perishDuration[0]) + "</color>";
				ConstructDataString();
			}
		}
	}
	
	public void Activate(ItemData data) {
		this.data = data;
		this.item = data.item;
		ConstructDataString();
		tooltip.SetActive(true);
	}

	public void DeActivate() {
		tooltip.SetActive(false);
	}

	public void ConstructDataString() {
		Text textDisplayer = tooltip.transform.GetChild(0).GetComponent<Text>(); 
		displayText = "<color=#0080FF><b>" + item.Title + "</b></color>\n\n" +
		"<color=#F2F2F2>" + item.Description + "</color>\n" +
		"<color=#FF0040>Atq : " + item.Power + "</color>\n" +
		"<color=#FF0040>Def : " + item.Defence + "</color>\n" +
		"<color=#FF0040>HP : " + item.Vitality + "</color>";
		
		if(item.Perishable) {
			displayText += timer;
		}
		textDisplayer.text = displayText;
	}
	
	
}
