[SerializedField]
GameObject alveoles; //Ces alveoles doivent avoir un rb avec gravity

/**
Il faudrait voir comment représenter les deux colliders : le mesh qui detecte la collision avec un projectile et le sol. et la sphereCollider qui va mettre les degats.
Ces spheres colliders vont probablement reservir plus tard ? Un héritage d'un collider mere qui detecte l'entrée d'un joueur dedans et un héritage qui applique des effets?
**/


private bool activated = false;
private bool hasHitFloor = false;
public void activate() {
	//TODO
	//Détacher de la branche principale ? (Suppression d'un lien de mesh ?) 
	//Enable le rigidbody/Gravity pour le faire tomber.
	activated = true;
}


private void Update() {
	if(activated)
		if(!hasHitFloor) {
			if(isGrounded()) 
				hasHitFloor = true;
		}
		else {
			//TODO Test de si la sphereCollideer n'est pas Enable et Enable la SphereCollider.
			//TODO Faire un compteur qui décrément au dela duquel on retire la sphereCollider par destruction du gameobject
			LootAlveoles();
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