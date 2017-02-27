using UnityEngine

public class Oiseaux {
	
	/** Cette version est une version simplifiée de la maquette. Ici , les oiseaux ne peuvent qu'être activés par le joueur et ne se déplace pas.
     * Il faudrait en apprendre plus sur les pathFinders et NavMeshAgent pour pouvoir leur donner une IA et savoir comment ils doivent se déplacer.
	 * En attendant, le script reste fonctionnel est plutot sympathique !
	**/ 
	[SerializeField]
	Collider triggerOiseaux
	
	[SerializeField]
	private float timerBeforeBirdsTakeOffInSec;
	[SerializeField]
	private float timerBeforeBirdsCanActivate;
	
	private bool activate = false;
	private bool activable = false;
	private bool flying = false;
	
	private void onTriggerStay(Collider otherCollider) {
		if(activable) {
			if(otherCollider.gameObject.CompareTag("Player")) {
				PlayerMovement playerMovement = otherCollider.gameObject.getComponent<PlayerMovement>();
				if(!playerMovement.isFurtive)
					activate = true;
			}
		}
	}
	
	private void Update() {
		if(!flying) {
			if(!activable) {
				timerBeforeBirdsCanActivate -= 1.0f * Time.deltaTime;
				if(timerBeforeBirdsCanActivate <= 0)
					activable = true;
				return;
			}
		
			if(activate) {
				moveBirdsByPlayer();
			}
			/*else {
				timerBeforeBirdsTakeOffInSec -= 1.0f * Time.deltaTime;
				if(timerBeforeBirdsTakeOffInSec <= 0) 
					moveBirdsNaturally();
			}*/
		}
		else
			moveBirds();
	}
	
	private void moveBirdsByPlayer(){
		//Display Son
		//Display GUI aux autres joueurs.
		moveBirdsNaturally();
	}
	
	
	private void moveBirdsNaturally(){
		activable = false;
		activate = false;
		flying = true;
	}
	
	private void moveBirds() 
		// Dans un premier temps, on ne fera que destroy ce gameObject, les modifications futures permettront le mouvement des oiseaux.
		// Ca me parait assez complexe comme fonctionnement a mettre en place et n'est pas déterminant pour le gameplay = on verra plus tard.
		Destroy(gameObject);
		// Fonction du mouvement qui detecte lorsque les oiseaux se sont reposés + reset le timerBeforeBirdsCanActivate
	}
}