using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAreaBehaviour : MonoBehaviour {

	[SerializeField]
	private MeshFilter takeOffArea;
	[SerializeField]
	private MeshFilter landingArea;
	
	public MeshFilter GetLandingArea() {
		return landingArea;
	}
	
	public MeshFilter GetTakeOffArea() {
		return takeOffArea;
	}
}
