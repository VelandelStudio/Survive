using UnityEngine;
using UnityEngine.UI;
 
public class TimedBuffer : MonoBehaviour {
   
	[SerializeField]
    private float duration; 
    [SerializeField]
	private float startTime; 
    [SerializeField]
	private float repeatTime;
    [SerializeField]
    private string hitZoneUIName;
	[SerializeField]
    private Image imageToDisplay;
	
    private GameObject target;
	private float leavingTime;
	
	private string textToDisplay = "";
	
    protected virtual void Start () {
		leavingTime = duration;
		DebuffDisplayerManager.Instance.DebuffAdded(gameObject);
        if (repeatTime > 0)
            InvokeRepeating("ApplyEffect", startTime, repeatTime);
        else
            Invoke("ApplyEffect", startTime);
    }
   
	protected virtual void Update() {
		leavingTime -= Time.deltaTime;
		if(leavingTime <= 0)
			EndEffect();
	}
	
    public virtual void ApplyEffect () {
    }

    public virtual void EndEffect () {
        CancelInvoke();
		DebuffDisplayerManager.Instance.DebuffRemoved(gameObject);
        Destroy(gameObject);
    }
	
	public float GetLeavingTime() {
		return leavingTime;
	}
	
	public float GetDuration() {
		return duration;
	}
	
	public virtual string GetTextToDisplay() {
		return textToDisplay;
	}
	
	public void SetDuration(float amount) {
		duration = amount;
	}
	
	public void AddDuration(float amount) {
		duration += amount;
		ResetDuration(duration);
	}
	
	public void ResetDuration(float amount) {
		leavingTime = amount;
	}

    public string GetHitZoneUiName()
    {
        return hitZoneUIName;
    }
	
	public Image GetImageToDisplay() {
		return imageToDisplay;
	}
}