[SerializedField]
GameObject collectacleGameObject;

private float respawnTimeInSec = 180.0f;

public virtual void SetRespawnTime(float respawnTimeInSec) {
	this.respawnTimeInSec = respawnTimeInSec;
}

private void Update() {
	respawnTimeInSec -= 1.0 * Time.deltaTime();
	
	if(respawnTimeInSec <= 0)
		respawnCollectable();
}

private void respawnCollectable() {
	Instantiate(collectacleGameObject, this.gameobject.transform, this.gameobject.rotation);
	Destroy(this.gameobject);
}