using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoisonZone : MonoBehaviour {

    private float timerPoisonTriggerInSec;
    private Collider poisonCollider;
    private void Start()
    {
        poisonCollider = gameObject.GetComponent<Collider>();
        poisonCollider.enabled = false;
        timerPoisonTriggerInSec = gameObject.GetComponentInParent<PlanteEmpoisonee>().GetTimerPoisonZone();
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
        if (otherCollider.gameObject.CompareTag("Player"))
            Debug.Log("Je mets un poison sur : " + otherCollider.gameObject.name);
    }

}
