using UnityEngine;
using System.Collections;
 
public class TimedEffect : MonoBehaviour {
   
	[SerliazeField]
    private float duration; 
    [SerliazeField]
	private float startTime; 
    [SerliazeField]
	private float repeatTime;
    
	private GameObject target;
	private float leavingTime;
	
	private string textToDisplay = "";
	
    private void Start () {
		leavingTime = duration;
        if (repeatTime > 0)
            InvokeRepeating("ApplyEffect", startTime, repeatTime);
        else
            Invoke("ApplyEffect", startTime);
		
        Invoke("EndEffect", duration);
    }
   
	private void Update() {
		leavingTime -= Time.deltaTime;
	}
	
    public virtual void ApplyEffect () {
    }

    public virtual void EndEffect () {
        CancelInvoke();
        Destroy(gameObject);
    }
	
	public float GetLeavingTime() {
		return leavingTime;
	}
	
	public virtual string GetTextToDisplay() {
		return textToDisplay;
	}
}