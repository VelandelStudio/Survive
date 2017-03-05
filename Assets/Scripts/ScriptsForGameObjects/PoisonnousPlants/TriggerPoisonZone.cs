using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoisonZone : MonoBehaviour {

    private float timerPoisonTriggerInSec;
    private Collider poisonCollider;
    private GameObject debuff;
	private void Start()
    {
        poisonCollider = gameObject.GetComponent<Collider>();
        poisonCollider.enabled = false;
        timerPoisonTriggerInSec = GetComponentInParent<PlanteEmpoisonee>().GetTimerPoisonZone();
		debuff = GetComponentInParent<PlanteEmpoisonee>().GetDebuffToApply();
    }

    private void Update()
    {
        if (poisonCollider.enabled)
            timerPoisonTriggerInSec -= 1.0f * Time.deltaTime;

        if (timerPoisonTriggerInSec <= 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player")) {
			GameObject debuffInstance = Instantiate(debuff);
			debuffInstance.transform.SetParent(otherCollider.gameObject.transform);
		}
    }	
}
