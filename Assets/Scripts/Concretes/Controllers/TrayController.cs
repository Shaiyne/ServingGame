using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayController : MonoBehaviour , IDrink
{
    [SerializeField] private Renderer drinkMaterial;
    GameObject bottle;
    private int earnMoneyFromDrink;
    DrinkStates _currentColor;
    private float _isFull;
    ScrollbarSizeCommand scrollbarSizeCommand;
    [SerializeField] private UIScrollbar _uiScrollbar;

    public float RedDrink { get ; set ; }
    public float BlueDrink { get; set; }
    public float YellowDrink { get; set; }
    public float WhiteDrink { get; set; }

    private void Awake()
    {
        bottle = transform.GetChild(0).gameObject;
        scrollbarSizeCommand = new ScrollbarSizeCommand(ref _uiScrollbar,this);
    }

    public void TrayActiveOrDeactive(bool value)
    {
        bottle.SetActive(value);
    }

    //public DrinkStates SetDrinkColor(string text)
    //{
    //    switch (text)
    //    {
    //        case "blue":
    //            drinkMaterial.material.SetColor("_Color", Color.blue);
    //            _currentColor = DrinkStates.Blue;
    //            earnMoneyFromDrink = 15;
    //            break;
    //        case "red":
    //            drinkMaterial.material.SetColor("_Color", Color.red);
    //            _currentColor = DrinkStates.Red;
    //            earnMoneyFromDrink = 20;
    //            break;
    //        case "yellow":
    //            drinkMaterial.material.SetColor("_Color", Color.yellow);
    //            _currentColor = DrinkStates.Yellow;
    //            earnMoneyFromDrink = 25;
    //            break;
    //        case "white":
    //            drinkMaterial.material.SetColor("_Color", Color.white);
    //            _currentColor = DrinkStates.White;
    //            earnMoneyFromDrink = 30;
    //            break;
    //    }

    //    return _currentColor;
    //}

    public void SetDrinkColor(string barrolColor)
    {
        switch (barrolColor)
        {
            case "blue":
                drinkMaterial.material.SetColor("_Color", Color.blue);
                _currentColor = DrinkStates.Blue;
                BlueDrink += 20 * Time.deltaTime;
                earnMoneyFromDrink = 15;
                break;
            case "red":
                drinkMaterial.material.SetColor("_Color", Color.red);
                _currentColor = DrinkStates.Red;
                RedDrink += 20 * Time.deltaTime;
                earnMoneyFromDrink = 20;
                break;
            case "yellow":
                drinkMaterial.material.SetColor("_Color", Color.yellow);
                _currentColor = DrinkStates.Yellow;
                YellowDrink += 20 * Time.deltaTime;
                earnMoneyFromDrink = 25;
                break;
            case "white":
                drinkMaterial.material.SetColor("_Color", Color.white);
                _currentColor = DrinkStates.White;
                WhiteDrink += 20 * Time.deltaTime;
                earnMoneyFromDrink = 30;
                break;
        }
        if (BlueDrink >= 100)
        {
            _currentColor = DrinkStates.Blue;
        }
        else if (RedDrink >= 100)
        {
            _currentColor = DrinkStates.Red;
        }
        else if (YellowDrink >= 100)
        {
            _currentColor = DrinkStates.Yellow;
        }
        else if (WhiteDrink >= 100)
        {
            _currentColor = DrinkStates.White;
        }
        else if (BlueDrink + YellowDrink >= 100)
        {
            _currentColor = DrinkStates.GreenMixed;
            earnMoneyFromDrink = 60;
        }
        else if (YellowDrink + RedDrink >= 100)
        {
            _currentColor = DrinkStates.OrangeMixed;
            earnMoneyFromDrink = 65;
        }
        else if (BlueDrink + RedDrink >= 100)
        {
            _currentColor = DrinkStates.PurpleMixed;
            earnMoneyFromDrink = 70;
        }

        else if (WhiteDrink + BlueDrink >= 100)
        {
            _currentColor = DrinkStates.CyanMixed;
            earnMoneyFromDrink = 80;
        }
    }

    public void CheckRequest(GameObject customerObject)
    {
        var scrollSize = scrollbarSizeCommand.Execute();
        if (customerObject.transform.GetComponent<CustomerController>()._customerRequest == _currentColor && scrollSize==1)
        {
            UISignals.Instance.onMoneyChange?.Invoke(earnMoneyFromDrink);
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.Idle);
            UISignals.Instance.onResetScrollbar?.Invoke();
            UISignals.Instance.onActivenesScrollbar?.Invoke(false);
            SetNullDrink();
            TrayActiveOrDeactive(false);
            CustomerSignals.Instance.onDestroyCustomer?.Invoke(customerObject.gameObject);
        }
    }

    public void SetNullDrink()
    {
        earnMoneyFromDrink = 0;
        BlueDrink = 0;
        RedDrink = 0;
        YellowDrink = 0;
        WhiteDrink = 0;
        _currentColor = DrinkStates.Null;
    }

    public int GetEarnMoney()
    {
        return earnMoneyFromDrink;
    }

    public int denem2me()
    {
        return ((int)_currentColor);
    }
}
