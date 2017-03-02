using UnityEngine;
using System;

public class Birds : MonoBehaviour {

	[SerializeField]
	Collider triggerBirds;
	[SerializeField]
	private float timerBeforeBirdsTakeOffInSec;
    [SerializeField]
    private float plueValueTimer;
    private float timerTmpTakeOff;

	[SerializeField]
	private float birdsSize;
	
	[SerializeField]
	private GameObject lootPlumePrefab;
	[SerializeField]
	private int minLoot;
	[SerializeField]
	private int maxLoot;
	private int nbLoot;
	
	private bool activate = false;
	private bool flying = false;
	private bool affraidByPlayer = false;
	
	private bool goingUp = false;
	private bool travelling = false;
	private bool goingDown = false;
	
	private Vector3 flyingDeparturePoint;
	private Vector3 flyingArrivalPoint;
	private float startTimeMovement;
	
	private BirdAreaBehaviour associatedArea;
	private MeshFilter meshFilterForNextMove;
	
	private void Start() {
		
		associatedArea = BirdAreasManager.Instance.BirdsLookingForArea(associatedArea);
		meshFilterForNextMove = associatedArea.GetLandingArea();
		gameObject.transform.position = meshFilterForNextMove.gameObject.transform.position+(new Vector3(0,birdsSize,0));
		
		nbLoot = MathHelper.GetRandInRangeInt(minLoot,maxLoot);
		HandleLootInstantiation();

		timerTmpTakeOff = timerBeforeBirdsTakeOffInSec + MathHelper.GetRandInRangeFloat(-plueValueTimer,plueValueTimer);
        CalculateNextPath();
		flyingDeparturePoint = transform.position;
	}
	
	private void OnTriggerStay(Collider otherCollider) {
		if(otherCollider.gameObject.CompareTag("Player")) {

			if(!flying) {
				///TODO : Decommenter pour tester sur dernier version pushed. Normalement ca devrait le faire !
				//PlayerMotor playerMotor = otherCollider.gameObject.getComponent<PlayerMotor>();
				//if(!playerMotor.isFurtive())
					activate = true;
			}
			else {
				if(!affraidByPlayer) {
					HandleTakingOff();
					moveBirdsNaturally();
				}
			}
		}
	}
	
	private void Update() {
		if(!flying) {			
			if(activate)
				moveBirdsByPlayer();
			else {
				timerTmpTakeOff -= 1.0f * Time.deltaTime;
				if(timerTmpTakeOff <= 0) 
					moveBirdsNaturally();
			}
		}
		else
			moveBirds();
	}
	
	private void moveBirdsByPlayer(){
		//Display Son
		//Display GUI aux autres joueurs.
		affraidByPlayer = true;
		moveBirdsNaturally();
	}
	
	private void moveBirdsNaturally(){
		startTimeMovement = Time.time;
		activate = false;
		flying = true;
		goingUp = true;
	}
	
	private void moveBirds() {
		transform.position = Vector3.Lerp(flyingDeparturePoint, flyingArrivalPoint, (Time.time - startTimeMovement));
		
		if(transform.position == flyingArrivalPoint) {
			flyingDeparturePoint = transform.position;
			startTimeMovement = Time.time;

			if(goingUp)
				HandleTravelling();
			else if(travelling)
				HandleLandingOn();
			else if(goingDown) {
				HandleLootInstantiation();
				HandleTakingOff();
				resetBirds();
			}
		}
	}
	
	private void HandleTravelling() {
		goingUp = false;
		
		associatedArea = BirdAreasManager.Instance.BirdsLookingForArea(associatedArea);	
		CalculateNextPath();

		travelling = true;
	}
	
	private void HandleLandingOn() {
		travelling = false;
		
		CheckForAssiocatedAreaNotNull(associatedArea);
		meshFilterForNextMove = associatedArea.GetLandingArea();
		flyingArrivalPoint = meshFilterForNextMove.gameObject.transform.position +(new Vector3(0,birdsSize,0));
		
		goingDown = true;
	}
	
	private void HandleTakingOff() {
		goingDown = false;
		
		timerTmpTakeOff = timerBeforeBirdsTakeOffInSec + MathHelper.GetRandInRangeFloat(-plueValueTimer,plueValueTimer);
        CalculateNextPath();
		flyingDeparturePoint = transform.position;
	}
	
	private void CalculateNextPath() {
		CheckForAssiocatedAreaNotNull(associatedArea);
		meshFilterForNextMove = associatedArea.GetTakeOffArea();
		Vector3[] vertices = meshFilterForNextMove.mesh.vertices;
		flyingArrivalPoint = meshFilterForNextMove.transform.TransformPoint(vertices[MathHelper.GetRandInRangeInt(0,vertices.Length-1)]);
	}
	
	private void resetBirds() {
		activate = false;
		flying = false;
		affraidByPlayer = false;
	}
	
	private void CheckForAssiocatedAreaNotNull(BirdAreaBehaviour area) {
		if(area == null) {
			Debug.LogError("Un groupe d'oiseau a rencontré un bug et a été détruit.");
			Destroy(gameObject);
		}
	}
	
	private void HandleLootInstantiation() {
		Vector3[] vertices = meshFilterForNextMove.mesh.vertices;
		for(int i = 0; i < nbLoot; i++) {
			Vector3 vertex = meshFilterForNextMove.transform.TransformPoint(vertices[MathHelper.GetRandInRangeInt(0,vertices.Length-1)]);
			Instantiate(lootPlumePrefab,new Vector3(vertex.x, vertex.y, vertex.z), Quaternion.Euler(0, MathHelper.GetRandInRangeInt(0,360), 0));
		}
		nbLoot = MathHelper.GetRandInRangeInt(minLoot,maxLoot);
	}
}