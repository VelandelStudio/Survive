private Text text;

private void Update() {	
	if(Physics.Raycast()) { //Raycast a courte distance
		ContainerCollectable itemCollectable = hitPoint.collider.getComponent<ContainerCollectable>()
		if(itemCollectable != null) {
			text = itemCollectable.getTextToDisplay();
			text.enabled = true;
			
			if(Input.getGey(KeyCode.E)
				itemCollectable.CollectObjectFromContainer();
		}	
		else
			text = null;
	}
}