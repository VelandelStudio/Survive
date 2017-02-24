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

private bool defRight = true; = false;
private float timerWhileUnderFurtiveAttack = 3.0f;

public bool isPlayerInCombat() {
	return playerInCombat;
}

public void setUnderFurtiveAttack() {
	underFurtiveAttack = true;
	for (int i = 0; i < 5; i++) {
		//TODO Tirage randon d'une touche du clavier parmi un certain nombre
		while(timerWhileUnderFurtiveAttack > 0) {
			//TODO Afficher quelques part à l'écran la touche a presser.
			if(Input.getKeyDown() == key) {
				break;
			}
			else {
				//TODO appliquer les degats/debuffs, le joueur a raté sa parade de l'attaque furtive.
				break;
			}
		}
		
		if(timerWhileUnderFurtiveAttack <= 0)
			//TODO appliquer les degats/debuffs, le joueur n'a pas appuyé pendant le temps imparti.

		timerWhileUnderFurtiveAttack = 3.0f;
	}
}

public bool isUnderFurtiveAttack() {
	return underFurtiveAttack;
}

private void onColliderEnter(Collider otherCollider) {
	
	otherPlayer = otherCollider.getComponent<PlayerCombat>();
	if(otherPlayer != null && otherPlayer.isPlayerInCombat) {
		//TODO Activation du LookAt
	}
}

private void onColliderExit(Collider otherCollider) {
	if(otherPlayer != null) {
		otherPlayer = null;
		//TODO Désactivation du lookAt
	}
}

private void Update() {
	if(underFurtiveAttack) {
		timerWhileUnderFurtiveAttack -= 1.0f * Time.deltaTime()
		return;
	}
	
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