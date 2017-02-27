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
	
    private void Start () {
        if (repeatTime > 0)
            InvokeRepeating("ApplyEffect", startTime, repeatTime);
        else
            Invoke("ApplyEffect", startTime);
		
        Invoke("EndEffect", duration);
    }
   
    public virtual void ApplyEffect () {
    }

    public virtual void EndEffect () {
        CancelInvoke();
        Destroy(gameObject);
    }
}