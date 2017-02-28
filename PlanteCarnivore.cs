using UnityEngine;

public class PlanteCarnivore {
	
	[SerializeField]
	private Collider triggerActivation;
	[SerializeField]
	private GameObject deadPlant;
	[SerializeField]
	private int countBeforeEscape;
	[SerializeField]
	private float timerToPressKey = 1.5f;
	
	private bool activated = false;
	private bool goodKeyPressed = false;
	private float timerTmp;
	private string keyToPress = "";
	private void Start() {
		timerTmp = timerToPressKey;
	}
	
	private void OnTriggerEnter(Collider otherCollider) {
		if(activated)
			return;
		
		if(otherCollider.gameObject.CompareTag("Player") {
			activated = true;
			otherCollider.gameObject.transform.position = this.gameObject.transform.postion;
			PlayerMovement player = otherCollider.gameObject.GetComponent<PlayerMovement>();
			
			///TODO : Ajouter cette méthode dans le playerMovement pour pouvoir l'empecher de bouger pendant qu'il est sous contrôle de la plante.
			player.SetUnableToMove();
		}
	}
	
	private void Update() {
		if(!activated)
			return;
		
		if(countBeforeEscape == 0) {
			Instantiate(deadPlant, this.gameobject.transform, this.gameobject.rotation);
			Destroy(this.gameObject);
		}
		
		if(timerTmp == timerToPressKey) {
			keyToPress = "a";
		}
		
		if(Input.GetKeyDown() == keyToPress) {
			keyToPress = "";
			timerTmp = TimerToPressKey;
			countBeforeEscape--;
		}
		else { /// TODO : verifier que ce bloc s'active bien si le joueur presse la mauvaise touche et pas simplement "si il n'appuie sur rien";
			keyToPress = "";
			timerTmp = TimerToPressKey;
			/// TODO : Appliquer blessures ! Le joueur s'est trompé de touche.
			countBeforeEscape--;
		}
		
		timerTmp -= 1.0 * Time.deltaTime;
		if(timerTmp <= 0) {
			///TODO Appliquer une blessure le temps imparti pour appuyer sur la touche est écoulé.
			keyToPress = "";
			timerTmp = TimerToPressKey;
			countBeforeEscape--;
		}
			
	}
}