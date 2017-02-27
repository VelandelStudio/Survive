using UnityEngine;

public class DebuffVomiting : IDebuff {
	
	private duration;
	private Component victim;
	private PlayerState playerState;
	
	private tickInit = 1.0f;
	private tickCurrent;
	
	public DebuffVomiting(int duration, Component victim) {
		this.duration = duration;
		this.victim = victim;
		if(victim.gameObject.CompareTag("Player"))
			playerState = victim.gameObject.getComponent<PlayerState>();
		
		tickCurrent = tickInit;
	}
	
    public void Apply() {
		if(tickCurrent <= 0) {
			
			if(playerState != null) {
				// Le joueur a 5% de chance chaque seconde de vomir. Si il vomit, le debuff disparait. Sinon il continue jusqu'au vomissement ou disparition.
				if(MathHelper.getRandInRangeInt(0,100) < 5 ) {
					playerState.setFoodBar(-25.0f);
					duration = 0f;
				}
			}
			else
				//Applique d'autres effets sur la faune (j'ai pas de scripts pour l'instant pour tester)
			
			tickCurrent = tickInit;
		}
	}
	public void Decrement(){
		duration -= 1.0f * Time.deltaTime;
		tickCurrent -= 1.0f * Time.deltaTime;
	}
	
	public float GetDuration() {
		return duration;
	}
}