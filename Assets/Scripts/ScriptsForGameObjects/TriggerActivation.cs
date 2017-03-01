using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour {

    private PlanteEmpoisonee mainCollider;

    private void Start()
    {
        mainCollider = GetComponentInParent<PlanteEmpoisonee>();
    }

    private void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Player"))
        {
            PlayerMotor playerMovement = otherCollider.gameObject.GetComponent<PlayerMotor>();
            if (!playerMovement.isFurtive())
                mainCollider.Activate();
        }
    }
}
