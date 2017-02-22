private float foodBar = 100f;
private float thirstBar = 100f;

private float hungerSpeed = 1f;
private float thirstSpeed = 2f;

private float hungerSpeedAdded = 0f;
private float thirstSpeedAdded = 0f;

#region getters/setters

public float getFoodBar() {
	return foodBar;
}

public float getThirstBar() {
	return thirstBar;
}

public void setFoodBar(float amount) {
	foodBar += amount;
}

public void setThirstBar(float amount) {
	thirstBar += amount;
}

public void addHungerSpeed(int amount) {
	this.hungerSpeedAdded += amount;
}

public void addThirstSpeed(int amount) {
	this.thirstSpeedAdded += amount;
}
#end region

private void Update() {
	updateHunger();
	updateThirst();
}

private void updateHunger() {
	setFoodBar(-(hungerSpeed + hungerSpeedAdded));
}

private void updateThirst() {
	setThirstBar(-thirstSpeed + thirstSpeedAdded);
}