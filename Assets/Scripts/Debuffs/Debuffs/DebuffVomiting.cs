using UnityEngine;
using UnityEngine.UI;

public class DebuffVomiting : TimedBuffer {
	///TODO : Ajouter une image associée au debuff dans le prefab
	private PlayerState playerState;

	protected override void Start() {
		//Si le debuff est deja présent, l'autre debuff est supprimé et seul celui-ci persiste (i.e. reset timer)/
		playerState = GetComponentInParent<PlayerState>();
		if(playerState != null) {
			DebuffVomiting[] otherDebuffs = playerState.GetComponentsInChildren<DebuffVomiting>();
			if(otherDebuffs.Length > 1){
				otherDebuffs[0].ResetDuration(GetDuration());
				//otherDebuffs[0].AddDuration(GetDuration());
				Destroy(gameObject);
			}
			else
				base.Start();
		}
	}
	
	protected override void Update() {
		base.Update();
	}
	
	public override void ApplyEffect() {
		//Ici ce debuff n'a d'effet que sur un joueur mais pas sur la faune !
		if(playerState != null) {
			if(MathHelper.GetRandInRangeInt(0,100) < 5) {
				playerState.SetFoodBar(-25.0f);
				EndEffect();
			}
		}
	}
	
	public override void EndEffect() {
		base.EndEffect();
	}
	
	public override string GetTextToDisplay() {
		return "Test de Texte";
	}
}