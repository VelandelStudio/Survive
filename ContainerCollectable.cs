[SerializedField]
GameObject depletedGameObject;
[SerializedField]
Text textField;
private void respawnDepleted() {
	Instantiate(depletedGameObject, this.gameobject.transform, this.gameobject.rotation);
	Destroy(this.gameobject);
}

public void CollectObjectFromContainer() {
	Debug.Log("Items Collected");
	respawnDepleted();
}

public Text getTextToDisplay() {
	return textField;
}
