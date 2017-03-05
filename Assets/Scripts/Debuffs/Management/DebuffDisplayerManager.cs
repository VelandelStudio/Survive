using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class DebuffDisplayerManager : MonoBehaviour {
	/// TODO : Normalement rien à ajouter. Peut etre le passage de la description du débuff au displayer; 
	[SerializeField]
	private GameObject debuffDisplayer;
	[SerializeField]
	private GameObject debuffSection;
    [SerializeField]
    private GameObject bodyImage;

    private static DebuffDisplayerManager instance; 
	public static DebuffDisplayerManager Instance {get {return instance;} }
	
	private List<GameObject> debuffs;
	private List<GameObject> debuffDisplayers;
	
	private void Awake() {
		if(instance != null && instance != this)
			Destroy(this.gameObject);
		else
			instance = this;
	}
	
	private void Start() {
		debuffs = new List<GameObject>();
		debuffDisplayers = new List<GameObject>();
	}
	
	private void Update() {
		for(int i = 0; i < debuffs.Count; i++) {
			float durationToDisplay = debuffs[i].GetComponent<TimedBuffer>().GetLeavingTime();
			debuffDisplayers[i].GetComponent<DebuffDisplayer>().UpdateDisplayer(durationToDisplay);
			AdjustPositionOfBuff(debuffDisplayers[i], i);
		}
	}
	
	public void DebuffAdded(GameObject debuff) {
		debuffs.Add(debuff);
		GameObject debuffDisplayerInstance = Instantiate(debuffDisplayer);
		debuffDisplayers.Add(debuffDisplayerInstance);
		debuffDisplayerInstance.transform.SetParent(debuffSection.gameObject.transform);
		debuffDisplayerInstance.GetComponent<DebuffDisplayer>().SetUpImageDebuff(debuff.GetComponentInChildren<Image>());
		debuffDisplayerInstance.GetComponent<DebuffDisplayer>().SetInitialDuration(debuff.GetComponent<TimedBuffer>().GetDuration());

        string UIZoneName = debuff.GetComponent<TimedBuffer>().GetHitZoneUiName();
        Transform[] hitZones = bodyImage.GetComponentsInChildren<Transform>(true);
        foreach (Transform hitZone in hitZones)
            if (hitZone.gameObject.name == UIZoneName)
            {
                hitZone.gameObject.SetActive(true);
                return;
            }
    }
	
	public void DebuffModified(GameObject debuff) {
		for(int i = 0; i < debuffs.Count; i++) {
			if(debuffs[i].Equals(debuff)) {
				GameObject debuffDisplayerInstance = debuffDisplayers[i];
				debuffDisplayerInstance.GetComponent<DebuffDisplayer>().SetUpImageDebuff(debuff.GetComponentInChildren<Image>());
			}
		}
	}
	
	public void DebuffRemoved(GameObject debuff) {
		for(int i = 0; i < debuffs.Count; i++)
			if(debuffs[i].Equals(debuff)) {
				debuffs.RemoveAt(i);
				Destroy(debuffDisplayers[i]);
				debuffDisplayers.RemoveAt(i);
			}
	}
	
	private void AdjustPositionOfBuff(GameObject debuff, int pos) {
		RectTransform rectTransform = debuff.GetComponent<RectTransform>();
		debuff.transform.position = debuffSection.transform.position - (new Vector3(0,rectTransform.rect.height/2.0f,0)) - pos * (new Vector3(0,rectTransform.rect.height,0));
	}
}