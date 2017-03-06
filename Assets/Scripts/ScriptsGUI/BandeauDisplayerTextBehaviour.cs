using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/** Script en charge d'afficher les informations du bandeau d'états lorsque le joueur passe la
 * souris sur l'une des images.
**/
public class BandeauDisplayerTextBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	
	[SerializeField]
	private PlayerState playerState;
	[SerializeField]
	private Image HungerImage;
	[SerializeField]
	private Image ThirstImage;
	[SerializeField]
	private GameObject textDisplayerOnMouse;
	
	private bool mouseHover = false;
	private RaycastResult resultRay;
	private Text textDisplayer;
	
	private void Start() {
		textDisplayer = textDisplayerOnMouse.GetComponentInChildren<Text>();
	}
	
	public void OnPointerEnter(PointerEventData eventData)
    {
		mouseHover = true;
		resultRay = eventData.pointerCurrentRaycast;
		textDisplayerOnMouse.SetActive(true);
    }
	
	public void OnPointerExit(PointerEventData eventData)
    {
		mouseHover = false;
			textDisplayerOnMouse.SetActive(false);
    }
	
	private void Update() {
		if(mouseHover) {
			RectTransform rectText = textDisplayer.GetComponent<RectTransform>();
			
			textDisplayerOnMouse.transform.position = Input.mousePosition + new Vector3(15,-10,0);
			if(resultRay.gameObject == HungerImage.gameObject) {
				textDisplayer.text = ("HELLO FOOoooooooooooooooooooooooooooooooooooooooooooooD : " + (int)playerState.GetFoodBar());
			}

			else if(resultRay.gameObject == ThirstImage.gameObject)
				textDisplayer.text = ("HELLO Thirst : " + (int)playerState.GetThirstBar());
			else
				textDisplayer.text = ("");
		}
		
	}
}
