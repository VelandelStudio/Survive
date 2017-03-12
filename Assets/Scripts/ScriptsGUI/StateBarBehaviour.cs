using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StateBarBehaviour : MonoBehaviour {

    private bool toggler = false;
    private RectTransform bandeau;
    [SerializeField]
    private PlayerState playerState;
    [SerializeField]
    private PlayerXPHandler playerXPHandler;
	
    [SerializeField]
    private Image HungerState;
    [SerializeField]
    private Image HungerBar;

    [SerializeField]
    private Image ThirstState;
    [SerializeField]
    private Image ThirstBar;

    [SerializeField]
    private Image XPState;
    [SerializeField]
    private Image XPBar;

    private void Start()
    {
        bandeau = GetComponent<RectTransform>();
    }

    void Update () {
        HandleToggler();

        HandleState(HungerState, HungerBar, playerState.GetFoodBar());
        HandleState(ThirstState, ThirstBar, playerState.GetThirstBar());
        HandleStateXP(XPState, XPBar, playerXPHandler.GetXPBarNormalized());
    }

    private void HandleToggler()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggler = !toggler;
        }

        if (toggler && bandeau.anchoredPosition.y != (bandeau.rect.height - 10))
        {
            gameObject.transform.position += Vector3.up;
        }

        if (!toggler && bandeau.anchoredPosition.y != 0)
        {
            gameObject.transform.position -= Vector3.up;
        }
    }

    private void HandleState(Image imageState, Image imageBar, float stateValue)
    {
        float stateValueFinal = stateValue / 100.0f;
        imageBar.fillAmount = stateValueFinal;
        imageState.fillAmount = stateValueFinal;
        setColor(imageBar);
    }
	
    private void HandleStateXP(Image imageState, Image imageBar, float stateValueFinal)
    {
        imageBar.fillAmount = stateValueFinal;
        imageState.fillAmount = stateValueFinal;
        setColor(imageBar);
    }

    private void setColor(Image image)
    {
        if (image.fillAmount > 0.75)
            image.color = Color.green;
        else if (image.fillAmount < 0.25)
            image.color = Color.red;
        else
            image.color = Color.yellow;
    } 
}
