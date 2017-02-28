using UnityEngine;

public class ContainerCollectable : ItemPickable {
	/** Un container collectable est un prefab qui contient des ItemsPickable. 
	 *  La différence avec un simple itemCollectable est que son prefab peut être remplacé par un autre momentanément(i.e. arbre à fruits -> arbre sans fruits -> respawn arbre a fruit),
	 *  ou simplement rester en l'état (i.e. un coffre plein devient un coffre vide)
	 *  Cette classe est une factory et doit être étendue et fonctionne (généralement) avec un ContainerDepleted.
	**/
	
	[SerializeField]
	private GameObject depletedGameObject;

	private void respawnDepleted() {
		Instantiate(depletedGameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
		Destroy(this.gameObject);
	}

	public override void onPickup() {
		///TODO : METHODE a modifier dans objet fils pour l'ajout des items collectés dans l'inventaire.
		respawnDepleted();
	}
}
