using UnityEngine;

public class ContainerDepleted : MonoBehavior {
/** ContainerDepleted fonctionne en coordination avec un ContainerCollectable. Il représente le containerCollectable dépourvu de ses ItemsPickable.
 *  Comme le container Collectable, cette classe est une Factory qui doit être étendue. Le respawnTimeInSec sera modifié dans les gameObjects fils.
**/

// TODO VERIFIER LE SCOPE DES METHODES ET VARIABLES DANS ELEMENTS FILS //
	[SerializeField]
	private GameObject collectacleGameObject;

	[SerializeField]
	private float respawnTimeInSec;


	private void Update() {
		respawnTimeInSec -= 1.0 * Time.deltaTime();
		
		if(respawnTimeInSec <= 0)
			respawnCollectable();
	}

	private void respawnCollectable() {
		Instantiate(collectacleGameObject, this.gameobject.transform, this.gameobject.rotation);
		Destroy(this.gameobject);
	}
}