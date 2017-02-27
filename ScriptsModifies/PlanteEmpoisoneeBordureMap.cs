using UnityEngine;

public class PlanteEmpoisonee : MonoBehavior {
	// Copie conforme de la plante empoisonnée mais, le poison est continuellement relaché
	// Cette fois, seuls les joueurs seront sensibles au poinson pour éviter qu'ils attirent la faune dedans et puisse les tuer facilement

	[SerializeField]
	private Collider poisonTrigger;
	
	private void Start() {
		poisonTrigger.enabled = true;
	}
	
	private void onTriggerStay(Collider otherCollider) {
		if(otherCollider.gameObject.CompareTag("Player") {
			//Aplliquer le poison
		}	
	}
}