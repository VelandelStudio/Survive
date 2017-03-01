using UnityEngine;

public class PlayerState : MonoBehaviour {

    private float foodBar = 100f;
    private float thirstBar = 100f;

    private float hungerSpeed = 1f;
    private float thirstSpeed = 2f;

    private float hungerSpeedAdded = 0f;
    private float thirstSpeedAdded = 0f;

    #region getters/setters

    public float GetFoodBar() {
        return foodBar;
    }

    public float GetThirstBar() {
        return thirstBar;
    }

    public void SetFoodBar(float amount) {
        foodBar += amount;
    }

    public void SetThirstBar(float amount) {
        thirstBar += amount;
    }

    public void AddHungerSpeed(int amount) {
        this.hungerSpeedAdded += amount;
    }

    public void AddThirstSpeed(int amount) {
        this.thirstSpeedAdded += amount;
    }
# endregion

    private void Update() {
        UpdateHunger();
        UpdateThirst();
    }

    private void UpdateHunger() {
        SetFoodBar(-(hungerSpeed*Time.deltaTime + hungerSpeedAdded));
    }

    private void UpdateThirst() {
        SetThirstBar(-thirstSpeed * Time.deltaTime + thirstSpeedAdded);
    }
}