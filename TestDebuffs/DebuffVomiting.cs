using UnityEngine;

public class DebuffVomiting : TimedBuffer {
	
	private PlayerState playerState;
	
	private void Start() {
		//Si le debuff est deja présent, l'autre debuff est supprimé et seul celui-ci persiste (i.e. reset timer)/
		playerState = getComponentInParent<PlayerState>();
		if(playerState != null) {
			DebuffVomiting[] otherDebuffs = playerState.getComponentsInChildren<DebuffVomiting>();
			if(otherDebuffs != null && otherDebuffs.length > 0){
				otherDebuffs.EndEffect();
			}
		}
		base.Start();
	}
	
	public override ApplyEffect() {
		//Ici ce debuff n'a d'effet que sur un joueur mais pas sur la faune !
		if(playerState != null) {
			if(MathHelper.getRandInRangeInt(0,100) < 5) {
				playerState.setFoodBar(-25.0f);
				EndEffect();
			}
		}
	}
	
	public override string GetTextToDisplay() {
		return "Test de Texte";
	}
}