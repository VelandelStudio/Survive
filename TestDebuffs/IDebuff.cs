using UnityEngine;

public Interface IDebuff : MonoBehavior{
	public void Apply();
	public void Decrement();
	public float GetDuration();
}
