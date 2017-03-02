using UnityEngine;

public class ContainerDepleted : MonoBehaviour {
/** ContainerDepleted fonctionne en coordination avec un ContainerCollectable. Il représente le containerCollectable dépourvu de ses ItemsPickable.
 *  Comme le container Collectable, cette classe est une Factory qui doit être étendue. Le respawnTimeInSec sera modifié dans les gameObjects fils.
**/

	[SerializeField]
	private GameObject collectacleGameObject;

	[SerializeField]
	private float respawnTimeInSec;

	private void Update() {
		respawnTimeInSec -= 1.0f * Time.deltaTime;
		
		if(respawnTimeInSec <= 0)
			respawnCollectable();
	}

	private void respawnCollectable() {
		Instantiate(collectacleGameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
		Destroy(this.gameObject);
	}
}