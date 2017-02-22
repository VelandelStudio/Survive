private float state = 100.0f;
private float feeding = 50.0f;
private int consoSpeed = 25;
private float perishSpeed = 0.5f;

public virtual void setItemStats(float state, float feeding, int consoSpeed) {
	this.state = state;
	this.consoSpeed = consoSpeed;
	this.feeding = feeding;
}

private void Start() {
	GameObject player = GameObject.findComponentWithTag("Player");
	PlayerInventory playerInventory = player.getComponent<PlayerInventory>();
	PlayerState playerState = player.getComponent<PlayerState>();
}

private void Update() {
		
	if(state <= 0) {
		Destroy(this.gameObject);
	}
	
	consumptionHandler();
	perishItemHandler();	
}

private void consumptionHandler() {
	if(playerInventory.getItemHeld() == this.gameObject.name) {
		
		if(Input.getButton("Fire2")){
			if(playerState.getFoodBar() < 100.0f) {
				state -= consoSpeed * Time.deltaTime();
				playerState.fillFoodBar(feeding * Time.deltaTime);
			}
		}
		
		if(Input.getButtonDown("Fire2")){
			if(playerState.getFoodBar() >= 100.0f) {
				Debug.Log("Not Possible, statiety = 100");
			}
		}
	}
}

private void perishItemHandler() {
	state -= perishSpeed Time.deltaTime();
}