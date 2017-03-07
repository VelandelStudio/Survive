using UnityEngine;

public class PlanteCarnivore : MonoBehaviour{
	
	[SerializeField]
	private Collider triggerActivation;
	[SerializeField]
	private GameObject deadPlant;
	[SerializeField]
	private int countBeforeEscape;
	[SerializeField]
	private float timerToPressKey = 1.5f;
	
	private bool activated = false;
	private bool keyPressed = true;
	private bool invokCancelled = true;
	
	private string keyToPress = "";
	private PlayerMotor player;
	private int countBadScore = 0;

	
	private void Start() {
	}
	
	private void OnTriggerEnter(Collider otherCollider) {
		if(activated)
			return;
		
		if(otherCollider.gameObject.CompareTag("Player")) {
			activated = true;
			otherCollider.gameObject.transform.position = gameObject.transform.position;
			player = otherCollider.gameObject.GetComponent<PlayerMotor>();
			player.SetUnableToMove(true);
			invokCancelled = false;
			InvokeRepeating("ApplyEffect",1,timerToPressKey);
		}
	}
	
	private void ApplyEffect() {
		countBeforeEscape--;
		/// TODO : Evoluer vers un tirage aleatoire des char. Regardez aussi comment disable l'ensemble des autres inputs ?
		string[] table = {"a","b","c","d","e"};
		if(!keyPressed)
			countBadScore ++;

		keyPressed = false;
		keyToPress = table[countBeforeEscape];
			
	}
	
	private void EndEffect() {
		player.SetUnableToMove(false);
		Instantiate(deadPlant, gameObject.transform.position, gameObject.transform.rotation);
		Debug.Log(countBadScore);
		Destroy(gameObject);
	}
	
	private void Update() {
		if(!activated)
			return;
		
		if(!keyPressed) {
			if(Input.inputString != "") {
				
				if(Input.inputString == keyToPress) {
					Debug.Log("GoodKeyPressed");
					keyToPress = "";
					keyPressed = true;
				}
				else {
					/// TODO : Soit on applique un debuff ici, soit on compte le nombre total de faute et on applique un debuff a la fin.
					Debug.Log("BadKeyPressed");
					countBadScore ++;
					keyPressed = true;
				}
			}
		}
		if(!invokCancelled && countBeforeEscape == 0) {
			invokCancelled = true;
			CancelInvoke();
			Invoke("EndEffect",1.5f);		
		}
	}
}