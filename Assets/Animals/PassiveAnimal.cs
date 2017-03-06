using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(NavMeshAgent))]

public class PassiveAnimal : AnimalBase{
	
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
	private bool affraidByPlayer = false;
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
				affraidByPlayer = true;
				navMeshAgent.speed = runSpeed;
				CancelInvoke();
			}
		}
	}
	
	private void Update() {
		if(affraidByPlayer) 
			Run();	
	}

	private void Run() {
		Vector3 dir = player.transform.position - transform.position;
		navMeshAgent.destination = transform.position - dir;
		
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if(dist > stopRunDistance) {
			affraidByPlayer = false;
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