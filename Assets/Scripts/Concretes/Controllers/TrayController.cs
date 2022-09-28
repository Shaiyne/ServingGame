using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayController : MonoBehaviour
{
    [SerializeField] private Renderer drinkMaterial;
    private int earnMoneyFromDrink;
    DrinkStates _currentColor;

    public void TrayActiveOrDeactive(bool value)
    {
        transform.GetChild(0).gameObject.SetActive(value);
    }

    public DrinkStates SetDrinkColor(string text)
    {
        switch (text)
        {
            case "blue":
                drinkMaterial.material.SetColor("_Color", Color.blue);
                _currentColor = DrinkStates.Blue;
                earnMoneyFromDrink = 15;
                break;
            case "red":
                drinkMaterial.material.SetColor("_Color", Color.red);
                _currentColor = DrinkStates.Red;
                earnMoneyFromDrink = 20;
                break;
            case "yellow":
                drinkMaterial.material.SetColor("_Color", Color.yellow);
                _currentColor = DrinkStates.Yellow;
                earnMoneyFromDrink = 25;
                break;
            case "white":
                drinkMaterial.material.SetColor("_Color", Color.white);
                _currentColor = DrinkStates.White;
                earnMoneyFromDrink = 30;
                break;
        }

        return _currentColor;
    }

    public void CheckRequest(DrinkStates drinkStates)
    {
        if (drinkStates == _currentColor)
        {
            UISignals.Instance.onMoneyCollect?.Invoke(earnMoneyFromDrink);
            SetNullDrink();
            TrayActiveOrDeactive(false);
        }
    }

    private void SetNullDrink()
    {
        earnMoneyFromDrink = 0;
    }
}
