[SerializedField]
GameObject alveoles; //Ces alveoles doivent avoir un rb avec gravity

/**
Il faudrait voir comment représenter les deux colliders : le mesh qui detecte la collision avec un projectile et le sol. et la sphereCollider qui va mettre les degats.
Ces spheres colliders vont probablement reservir plus tard ? Un héritage d'un collider mere qui detecte l'entrée d'un joueur dedans et un héritage qui applique des effets?
**/

private bool activated = false;
private bool hasHitFloor = false;
private float timerOfBees = 15.0f; 

public void activate() {
	//TODO
	RigidBody rb = getComponent<RigidBody>();
	if(rb != null)
		rb.isKinematic = false;
	
	activated = true;
}


private void Update() {
	if(activated) {
		if(!hasHitFloor) {
			if(isGrounded()) {
				hasHitFloor = true;
				LootAlveoles();
				//TODO Enable la SphereCollider.
			}
		}
		else {
			timerOfBees -= 1.0 * Time.deltaTime(); 
			if(timerOfBees <= 0)
				Destroy(gameObject);
		}
	}
}

private void LootAlveoles() {
	//TODO : Evoluer vers un random entre 1 et 3 ?
	int nbLoot = 2;
	
	for int(i = 0; i < nbLoot; i++)
		Instanciate(alveoles, gameObject.transform, gameObject.rotation);
}

private bool isGrounded(){
	//TODO return le resultat du raycast de l'objet vers le sol
}