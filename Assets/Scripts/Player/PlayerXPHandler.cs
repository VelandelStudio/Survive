using UnityEngine;

public class PlayerXPHandler : MonoBehaviour {
    private float XPBar = 1f;
    private float XPSpeed = 0.01f;
    private float XPSpeedAdded = 0f;
	private int talentPoints = 0;
	private int level = 1;
	private float cumul = 0;
	
	public float GetXPBar() {
        return XPBar;
    }
	
	public float GetXPBarNormalized() {		
		return (Mathf.Sqrt(XPBar) * 1 - level);
    }
	
    public void SetXPBar(float amount) {
        XPBar = amount;
    }
	
    public void AddXPBar(float amount) {
        XPBar += amount;
    }
	
	public void AddXPBarInPercent(float amount) {
        XPBar += (amount/100)*(Mathf.Pow(level+1,2) - cumul);
    }
	
	public void AddXPSpeed(float amount) {
        XPSpeedAdded += amount;
    }
	
	public int GetLevel() {
		return level;
	}
	
	public int GetTalentPoints() {
        return talentPoints;
    }
	
	public void UseTalentPoint() {
		if(talentPoints > 0)
			talentPoints--;
	}
	
	private void Update() {
		AddXPBar((XPSpeed + XPSpeedAdded) * Time.deltaTime);
		if(Mathf.Sqrt(XPBar) * 1 >= (level+1))
			LevelUp();
	}
	
	private void LevelUp() {
		cumul = XPBar;
		level++;
		talentPoints++;
	}
}