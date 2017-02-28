using UnityEngine;
using UnityEngine.UI;

public class StateBar : MonoBehavior{
	[SerializeField]
	private PlayerState playerState;
	
	[SerializeField]
	private Image HungerState;
	[SerializeField]
	private Image HungerBar;
	
	[SerializeField]
	private Image ThirstState;
	[SerializeField]
	private Image ThirstBar;
	
	[SerializeField]
	private Image XPState;
	[SerializeField]
	private Image XPBar;
	
	private bool isVisible = true;
	
	private void Update() {
		HandleState(HungerState, HungerBar, playerState.GetFoodBar());
		HandleState(ThirstState, ThirstBar, playerState.GetThirstBar());
		HandleState(XPState, XPBar, playerState.GetXPBar());
		
		/// TODO : Ajouter l'input de Tabulation.
		if(Input.GetButtonDown("Tabulation")) {
			if(isVisible)
				HideStates();
			else
				ShowStates();
			visible = !visible;
		}
	}
	
	private void HandleHungerState(Image imageState, Image imageBar, float stateValue) {
		float stateValueFinal = stateValue/100.0f;
		imageBar.fillAmount = stateValueFinal;
		imageState.fillAmount = stateValueFinal;
		setColor(imageBar);
	}
	
	private void setColor(Image image) {
		if(image.fillAmount > 0.75)
			image.color = Color.green;
		else if(image.fillAmount < 0.25)
			image.color = Color.red;
		else
			image.color = Color.yellow;
	}
	
	private void HideStates() {
		/// TODO	
	}
	private void ShowStates() {
		///TODO	
	}
}