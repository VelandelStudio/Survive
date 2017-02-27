using UnityEngine;
using UnityEngine.UI;

public class Ruche : ItemsActivable
{
    [SerializeField]
    private GameObject alveoles;
    [SerializeField]
    private SphereCollider sphereBees;
	[SerializeField]
	private float timerOfBees;
	[SerializeField]
	private int nbMinLoot;
	[SerializeField]
	private int nbMaxLoot;
    
	/**
    Il faudrait voir comment représenter les deux colliders : le mesh qui detecte la collision avec un projectile et le sol. et la sphereCollider qui va mettre les degats.
    Ces spheres colliders vont probablement reservir plus tard ? Un héritage d'un collider mere qui detecte l'entrée d'un joueur dedans et un héritage qui applique des effets?
    **/
	
    private Rigidbody rb;
    private bool activated = false;
    private bool hasHitFloor = false;
     
    public override void onActivation() {
		if(!activated) {
			rb = GetComponent<Rigidbody>();
			if(rb != null)
				rb.isKinematic = false;
		
			activated = true;
		}
    }

    private void Update() {
	    if(activated) {
		    if(hasHitFloor) {
                timerOfBees -= 1.0f * Time.deltaTime;
                if (timerOfBees <= 0)
                    Destroy(gameObject);
		    }
	    }
    }

    private void LootAlveoles() {
		int nbLoot = MathHelper.getRandInRangeInt(nbMinLoot, nbMaxLoot);
	    for (int i = 0; i < nbLoot; i++)
		    Instantiate(alveoles, gameObject.transform.position, gameObject.transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            hasHitFloor= true;
            rb.isKinematic = true;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            sphereBees.enabled = true;
            LootAlveoles();
        }
    }
}