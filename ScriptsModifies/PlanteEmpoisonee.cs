using UnityEngine;

public class PlanteEmpoisonee : MonoBehaviour {
	//TODO : La gestion de détection du déplacement sera mise en place quand le script de mouvement du joueur sera mis en place.
	//TODO Il faudra réfléchir à l'explosion même de la plante ? Est ce que le prefab disparait ou pas ?
	//  Je pensais plutot à une sorte d'animation où la plante fane et se couche à moitié sur le sol et reste la pour le restant de la partie. 
	//  Cela donne l'information aux joueurs qu'un autre joueur est deja passé par là etc..
	
	[SerializeField]
	private Collider activationTrigger;
	[SerializeField]
	private Collider poisonTrigger;
	[SerializeField]
	private float timerPoisonTriggerInSec;
	
	private bool activated = false;
	
	private void Start() {
		activationTrigger.enabled = true;
		poisonTrigger.enabled = false;
	}
	
	private void Update(){
		if(activated && poisonTrigger.enabled) {
			timerPoisonTriggerInSec -= 1.0f * Time.deltaTime;
			if(timerPoisonTriggerInSec <= 0)
				poisonTrigger.enabled = false;
		}
	}
	
	private void OnCollisionEnter(Collision collision) {
		if(!activated)
			activate();
	}
	
	private void onTriggerStay(Collider otherCollider) {
		if(!activated) {
			if(otherCollider is IEntityLiving) {
				if(otherCollider.gameObject.CompareTag("Player")) {
					/* gestion de la detection du type de mouvement de joueur : si furtif return) 
					PlayerMovement playerMovement = otherCollider.gameObject.getComponent<PlayerMovement>();
					if(playerMovement.isFurtive)
						return; */
				}
				activate();
			}	
		}
		else {
			//TODO Appliquer le poison au joueur.
		}
			
	}
	
	private void activate() {
		activationTrigger.enabled = false;
		activated = true;
		poisonTrigger.enabled = true;
	}
}