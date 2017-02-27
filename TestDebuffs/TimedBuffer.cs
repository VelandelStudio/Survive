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
	
	public TimedEffect(GameObject target) {
		this.target = target;
		this.transform.parent = target;
		//TODO : Voir comment attacher un gameObject sauvage a un objet deja existant !
	}
   
    void Start () {
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