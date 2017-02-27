using UnityEngine;

public class DebuffVomiting : TimedBuffer {
	
	PlayerState playerState;
	
	public DebuffVomiting(GameObject target) {
		base(target);
		playerState = target.getComponent<PlayerState>();
	}
	
	protected override ApplyEffect() {
		//Ici ce debuff n'a d'effet que sur un joueur mais pas sur la faune !
		if(playerState != null) {
			if(MathHelper.getRandInRangeInt(0,100) < 5) {
				playerState.setFoodBar(-25.0f);
				base.EndEffect();
			}
		}
	}
}