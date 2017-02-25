using UnityEngine;
using UnityEngine.UI;

public class Ruche : ItemsActivable
{
    [SerializeField]
    GameObject alveoles; //Ces alveoles doivent avoir un rb avec gravity
    [SerializeField]
    SphereCollider sphereBees;
    /**
    Il faudrait voir comment représenter les deux colliders : le mesh qui detecte la collision avec un projectile et le sol. et la sphereCollider qui va mettre les degats.
    Ces spheres colliders vont probablement reservir plus tard ? Un héritage d'un collider mere qui detecte l'entrée d'un joueur dedans et un héritage qui applique des effets?
    **/
    private Rigidbody rb;
    private bool activated = false;
    private bool hasHitFloor = false;
    private float timerOfBees = 15.0f; 

    public void activate() {
	    rb = GetComponent<Rigidbody>();
	    if(rb != null)
		    rb.isKinematic = false;
	
	    activated = true;
    }

    protected override void Start()
    {
        base.Start();
    }

    private void Update() {
        if (!activated && Input.GetKeyDown(KeyCode.J))
            displayTextActivableIem();

        if (!activated && Input.GetKeyDown(KeyCode.E))
            activate(); 

	    if(activated) {
		    if(hasHitFloor) {
                timerOfBees -= 1.0f * Time.deltaTime;
                if (timerOfBees <= 0)
                    Destroy(gameObject);
		    }
	    }
    }

    private void LootAlveoles() {
	    //TODO : Evoluer vers un random entre 1 et 3 ?
	    int nbLoot = 2;
	
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