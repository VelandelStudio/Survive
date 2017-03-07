using UnityEngine;

public class DeadAnimal : MonoBehaviour {

	[SerializeField]
	private float timeToDespawn;
	
	private void Start() {
		Invoke("Despawn", timeToDespawn);
	}
	
	private void Despawn() {
		Destroy(gameObject);
	}
}