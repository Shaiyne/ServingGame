using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayController : MonoBehaviour , IColors
{
    [SerializeField] public Renderer drinkColor;
    [SerializeField] public Image circleColor;
    [SerializeField] public Sprite[] circleSprites;
    GameObject bottle;
    private float _isScrollbarFull;
    ColorPlayerCommand circlePlayerCommand;
    public float RedDrink { get ; set ; }
    public float BlueDrink { get; set; }
    public float YellowDrink { get; set; }
    public float WhiteDrink { get; set; }
    public int EarnMoneyFromDrink { get; set; }
    public DrinkStates CurrentColor { get; set; }
    public Color Color { get; set; }
    private void Awake()
    {
        bottle = transform.GetChild(0).gameObject;
        circlePlayerCommand = new ColorPlayerCommand(this);
    }
    private void OnEnable()
    {
        TraySignals.Instance.onCurrentScrollbarValue += GetCurrentScrollbarValue;
    }
    public void TrayActiveOrDeactive(bool value)
    {
        bottle.SetActive(value);
    }

    public void SetDrinkColor(string barrolColor)
    {
        circlePlayerCommand.SetDrinkStates(barrolColor);
        circlePlayerCommand.Execute();
        circleColor.sprite = circleSprites[(int)CurrentColor];
        drinkColor.material.SetColor("_Color", Color);
    }


    public void CheckRequest(GameObject customerObject)
    {
        var isFull = _isScrollbarFull;
        if (customerObject.transform.GetComponent<CustomerController>()._customerRequest == CurrentColor && isFull==1)
        {
            UISignals.Instance.onMoneyChange?.Invoke(EarnMoneyFromDrink);
            UpgradeSignals.Instance.onGetMoney?.Invoke(EarnMoneyFromDrink);
            InputSignals.Instance.onAnimationInputState?.Invoke(PlayerAnimationStates.Idle);
            UISignals.Instance.onResetScrollbar?.Invoke();
            UISignals.Instance.onActivenesScrollbar?.Invoke(false);
            SetNullDrink();
            TrayActiveOrDeactive(false);
            CustomerSignals.Instance.onDeactiveCustomer?.Invoke(customerObject.gameObject);
            CustomerSignals.Instance.onDeskNull?.Invoke();
            FindObjectOfType<AudioManager>().Play("OrderCompleteSound");
        }
    }
    private void GetCurrentScrollbarValue(float value)
    {
        _isScrollbarFull = value;
    }

    public void SetNullDrink()
    {
        EarnMoneyFromDrink = 0;
        BlueDrink = 0;
        RedDrink = 0;
        YellowDrink = 0;
        WhiteDrink = 0;
        CurrentColor = DrinkStates.Null;
        Color = Color.black;
        circleColor.sprite = circleSprites[(int)CurrentColor];
        circlePlayerCommand.SetNullAll();
    }

    public int GetEarnMoney()
    {
        return EarnMoneyFromDrink;
    }

    public int GetCurrentColor()
    {
        return ((int)CurrentColor);
    }

}
