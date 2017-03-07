using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/** Script en charge d'afficher les informations du bandeau d'états lorsque le joueur passe la
 * souris sur l'une des images.
**/
public class BandeauDisplayerTextBehaviour : MonoBehaviour {
	
	[SerializeField]
	private PlayerState playerState;
	[SerializeField]
	private Image HungerImage;
	[SerializeField]
	private Image ThirstImage;
	[SerializeField]
	private GameObject textDisplayerOnMouse;
	
	private bool mouseHover = false;
	private Text textDisplayer;
	private GameObject objectHovered;
	
	private void Start() {
		textDisplayer = textDisplayerOnMouse.GetComponentInChildren<Text>();
	}
	
	private void Update() {
		if(mouseHover) {
			textDisplayerOnMouse.SetActive(true);
			
			textDisplayerOnMouse.transform.position = Input.mousePosition + new Vector3(15,-10,0);
			if(objectHovered == HungerImage.gameObject) {
				textDisplayer.text = ("HELLO FOOOPOOOOOOOOOOOOD : " + (int)playerState.GetFoodBar());
			}
			else if(objectHovered == ThirstImage.gameObject)
				textDisplayer.text = ("HELLO Thirst : " + (int)playerState.GetThirstBar());
			else
				textDisplayer.text = ("");
		}
		else		
			textDisplayerOnMouse.SetActive(false);
	}
	
	public void DisplayText(GameObject obj) { 
		mouseHover = true;
		objectHovered = obj;
	}
	
	public void CancelText() { 
		mouseHover = false;
	}
}