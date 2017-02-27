using UnityEngine;
using UnityEngine.UI

public class PlayerDebuffs : MonoBehavior {
	
	private debuffs = new List<IDebuff>;
		
	private void Start() {}
	
	private void Update {
		for(int i = 0; i < debuffs.count; i++) {
			debuff.Apply();
			debuff.Decrement();
			if(debuff.duration <= 0)
				debuffs.RemoveAtIndex(i);
		}
		
	}
	
	public void addDebuff(Debuff debuff) {
		if(debuffs.count > 0) {
			foreach(IDebuff debuffInList in debuffs) {
				if(debuffInList.getName() == debuf.getName()) {
					(debuffInList.duration = debuffInList.duration > debuff.duration ? debuffInList.duration : debuff.duration)	
					return;
				}
			}
		}
		debuffs.Add(debuff);
	}
}