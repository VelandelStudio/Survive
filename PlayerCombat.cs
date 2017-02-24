[RequiredComponent(typeof(Collider))]

[SerializedField]
private Collider playerCollider;

private PlayerCombat otherPlayer;
private bool playerInCombat;

private void onColliderEnter(Collider otherCollider) {
	
	otherPlayer = otherCollider.getComponent<PlayerCombat>();
	if(otherPlayer != null && otherPlayer.isPlayerInCombat) {
		//Activation du LookAt
	}
}

private void onColliderExit(Collider otherCollider) {
	if(otherPlayer != null) {
		otherPlayer = null;
		//Désactivation du lookAt
	}
}

private void Update() {
	if(Input.getKey(KeyCode.F1))
		playerInCombat = !playerInCombat;
	
	if(playerInCombat)
		playerCollider.enabled = true;
	
	if(playerInCombat) {
		if(otherPlayer != null && otherPlayer.isPlayerInCombat)
			//Si les deux joueurs sont en mode combat : Activation du "duel"
		else
			if(Input.getButton("Fire1")  {
				//Si le joueur est en mode combat mais qu'il n'a pas de cible de type joueur ou que l'autre joueur n'est pas en mode combat
				//Il peut attaquer sans la contrainte  des règles du duel. (AhLbatard) !
				PlayerWeapon weapon = getComponentInChildren<PlayerWeapon>()
					(if weapon != null)
						weapon.Attack();
			}
	}
}

public bool isPlayerInCombat() {
	return playerInCombat;
}

