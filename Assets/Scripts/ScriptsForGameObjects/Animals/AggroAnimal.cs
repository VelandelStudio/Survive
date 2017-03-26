using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent))]

public class AggroAnimal : AnimalBase{

	[SerializeField]
	private float walkSpeed;
	[SerializeField]
	private float stopRunDistance;
	[SerializeField]
	private float runSpeed;
	[SerializeField]
	private float minTimeBeforeWalk;
	[SerializeField]
	private float maxTimeBeforeWalk;
	[SerializeField]
	private float maxDistanceWalk;
	
	private UnityEngine.AI.NavMeshAgent navMeshAgent;
	private GameObject player;
	private bool playerDetected = false;
	private float nextWalkMovement;
	
	private void Start() {
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		navMeshAgent.speed = walkSpeed;
		nextWalkMovement = maxTimeBeforeWalk;
		InvokeRepeating("Walk",nextWalkMovement,nextWalkMovement);
	}
	
	private void OnTriggerStay(Collider otherCollider) {
		if(otherCollider.gameObject.CompareTag("Player")) {
			player = otherCollider.gameObject;
			PlayerMotor playerMovement = player.GetComponent<PlayerMotor>();
			
			if(!playerMovement.isFurtive()) {
				playerDetected = true;
				navMeshAgent.speed = runSpeed;
				CancelInvoke();
			}
		}
	}
	
	private void Update() {
		///TODO Ajouter une detection de "Si le joueur est à porte d'attaque alors on l'attaque".
		///Pour l'attaque en elle même je ne sais pas trop, il faudra voir ensemble si on fait un systeme de combat basique ? ou si on fait en sorte
		///que le joueur subisse comme une attaque furtive ? A voir.	
		if(playerDetected) 
			Run();	
	}

	private void Run() {
		Vector3 dir = player.transform.position - transform.position;
		Debug.Log(dir.normalized);
		navMeshAgent.destination = transform.position + dir;
		
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if(dist > stopRunDistance) {
			playerDetected = false;
			navMeshAgent.speed = walkSpeed;
			InvokeRepeating("Walk",nextWalkMovement,nextWalkMovement);
		}
	}

	private void Walk() {
		Vector3 randomDirection = Random.insideUnitSphere * maxDistanceWalk;
		navMeshAgent.destination = transform.position + randomDirection;
		nextWalkMovement = MathHelper.GetRandInRangeFloat(minTimeBeforeWalk,maxTimeBeforeWalk);
	}
}