[RequiredComponent(typeof(Collider))]

[SerializedField]
private Collider playerCollider;

private PlayerCombat otherPlayer;
private bool playerInCombat;
private PlayerWeapon weapon;

private bool defTop = false;
private bool defLeft = false;
private bool defBot = false;
private bool defRight = false;
private bool[] defSides = {defTop, defRight, defBot, defLeft};


public bool isPlayerInCombat() {
	return playerInCombat;
}

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
		switchCombatMode();
	
	if(playerInCombat) {
		weapon = getComponentInChildren<PlayerWeapon>();

		if(otherPlayer != null && otherPlayer.isPlayerInCombat)
			//Si les deux joueurs sont en mode combat : Activation du "duel" : Le duel est en commentaire car je veux d'abord fixer les bugs de la caméra avec LookAt
			//handleCombatMode(weapon.getType())
		else
			if(Input.getButton("Fire1")  {
				//Si le joueur est en mode combat mais qu'il n'a pas de cible de type joueur ou que l'autre joueur n'est pas en mode combat
				//Il peut attaquer sans la contrainte  des règles du duel. (AhLbatard) !
					(if weapon != null)
						weapon.Attack();
			}
	}
}


private void switchCombatMode() {
	if(playerInCombat) {
		playerInCombat = false;
		resetDefSides();
		playerCollider.enabled = false;
	}
	else {
		playerInCombat = true;
		playerCollider.enabled = true;
	}
}

private void resetDefSides() {
	foreach(bool side in defSides)
		side = false;
}

private void handleCombatMode(String weaponType) {
	if(Strig.Equals(weaponType, "OFFENSIF") {
		//Gestion du combat avec armes offensives (on verra plus tard j'y ai pas refléchi)
	}
		
	else if(Strig.Equals(weaponType, "DEFENSIF") {
		if(!defLeft && !defRight && !defTop && !defBot) {
			defTop = true;
			defRight = true;
		}
		
		if(Input.getKeyDown(/*Combinaison SHIFT + E*/)) {
			resetDefSides();
			defTop = true;
			defRight = true;
		}
		else if(Input.getKeyDown(/*Combinaison SHIFT + W*/)) {
			resetDefSides();
			defBot = true;
			defLeft = true;
		}
	}
	
	else if(Strig.Equals(weaponType, "MIXTE") {
		
		if(!defLeft && !defRight && !defTop && !defBot)
			defRight = true;
		
		if(Input.getKeyDown(/*Combinaison SHIFT + Z*/)) {
			resetDefSides();
			defTop = true;
		}
		else if(Input.getKeyDown(/*Combinaison SHIFT + D*/)) {
			resetDefSides();
			defRight = true;
		}
		else if(Input.getKeyDown(/*Combinaison SHIFT + S*/)) {
			resetDefSides();
			defBot = true;
		}
		else if(Input.getKeyDown(/*Combinaison SHIFT + Q*/)) {
			resetDefSides();
			defLeft = true;
		}
	}	
}

