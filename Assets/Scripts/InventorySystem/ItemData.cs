using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
	public Item item;
	public int stackSize;
	public int slotID;
	public List<float> perishDuration;
	public float timeToDestroy;
	public Image fillerImage;
	public Image fillerBackground;
	
	private Vector2 offset;
	private Tooltip tooltip;
	private ButtonPanel buttonPanel;
	
	private void Start() {
		tooltip = Inventory.Instance.gameObject.GetComponent<Tooltip>();
		buttonPanel = Inventory.Instance.gameObject.GetComponent<ButtonPanel>();
	}
	
	private void Update() {
		if(perishDuration == null || perishDuration.Count == 0)
			return;
		
		fillerImage.fillAmount = perishDuration[0]/timeToDestroy;
		UpdateFillerColor();
		for (int i = 0; i < perishDuration.Count; i++) {
			perishDuration[i] -= Time.deltaTime;
			if(perishDuration[i] <= 0) {
				Inventory.Instance.DestroyItem(this);
			}
		}
	}

	private void UpdateFillerColor() {
		if(fillerImage.fillAmount > 0.75)
			fillerImage.color = Color.green;
		else if(fillerImage.fillAmount < 0.25)
			fillerImage.color = Color.red;
		else
			fillerImage.color = Color.yellow;
	}
	
	private bool itemDraggedOutOfInv(PointerEventData eventData) {
		if(eventData.pointerCurrentRaycast.gameObject == null)
			return true;
		
		string hitName = eventData.pointerCurrentRaycast.gameObject.name;
		if(Inventory.Instance.gameObject.name == hitName)
			return false;
		
		Transform[] transforms = Inventory.Instance.gameObject.GetComponentsInChildren<Transform>();
		foreach(Transform trans in transforms) {
			if(trans.gameObject.name == hitName)
				return false;
		}
		return true;
	}
	
	#region buttons OnClick Methods
	public void UseItem() {
		Debug.Log("ItemUsed");
	}
	
	public void EatItem() {
		Debug.Log("ItemAte");
	}
	#endregion
	
	#region Interfaces MouseBehaviour	
	public void OnBeginDrag(PointerEventData eventData) {
		if(item != null) {
            buttonPanel.DeActivate();
			offset = eventData.position - new Vector2(this.transform.position.x,this.transform.position.y);
			this.transform.position = eventData.position - offset;
			this.transform.SetParent(this.transform.parent.parent);
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
	
	public void OnDrag(PointerEventData eventData) {
		if(item != null) {
			this.transform.position = eventData.position - offset;
			tooltip.DeActivate();
		}
	}
	
	public void OnEndDrag(PointerEventData eventData) {
		if(itemDraggedOutOfInv(eventData)) {
			Inventory.Instance.RemoveItem(this);
		}
		else {
			this.transform.SetParent(Inventory.Instance.slots[slotID].transform);
			this.transform.position = Inventory.Instance.slots[slotID].transform.position;
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
	}
	
	public void OnPointerEnter(PointerEventData eventData) {
		tooltip.Activate(this);
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		tooltip.DeActivate();
	}
	
	public void OnPointerClick(PointerEventData eventData) {
		if(eventData.button == PointerEventData.InputButton.Right) {
			buttonPanel.Activate(this);
			tooltip.DeActivate();
		}
	}
#endregion
}