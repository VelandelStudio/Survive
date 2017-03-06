using UnityEngine;

public class CursorBehaviour : MonoBehaviour {
	private void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	private void Update() {
		
		if(Input.GetKey(KeyCode.LeftAlt))
			Cursor.lockState = CursorLockMode.None;
		else
			Cursor.lockState = CursorLockMode.Locked;
	}
}
