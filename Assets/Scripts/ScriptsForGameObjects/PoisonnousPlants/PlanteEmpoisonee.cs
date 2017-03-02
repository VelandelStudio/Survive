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
    private float timerPoisonZone;

    private bool isDead = false;

    private void OnCollisionEnter(Collision collision) {
        if (!isDead)
            Activate();

    }

    public void Activate()
    {
        Destroy(activationTrigger.gameObject);
        poisonTrigger.enabled = true;
        isDead = true;
    }

    public float GetTimerPoisonZone()
    {
        return timerPoisonZone;
    }
}