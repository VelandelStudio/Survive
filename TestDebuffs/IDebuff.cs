using UnityEngine;

public Interface IDebuff {
	public void Apply();
	public void Decrement();
	public float GetDuration();
}