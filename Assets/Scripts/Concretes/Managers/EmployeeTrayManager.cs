using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeTrayManager : MonoBehaviour , IColors
{
    [SerializeField] private Sprite[] _drinkSprites;
    [SerializeField] private Image _drinkImages;
    [SerializeField] Renderer _drinkRenderer;
    string emplooyerName;
    GameObject tray;

    public float RedDrink { get; set; }
    public float BlueDrink { get; set; }
    public float YellowDrink { get; set; }
    public float WhiteDrink { get; set; }
    public int EarnMoneyFromDrink { get; set; }
    public DrinkStates CurrentColor { get; set; }
    public Color Color { get; set; }
    ColorEmployeeCommand circleEmployeeCommand;

    private void Awake()
    {
        emplooyerName = this.gameObject.transform.parent.name;
        circleEmployeeCommand = new ColorEmployeeCommand(this);
        tray = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        //Debug.Log(CurrentColor);
    }
    private void OnEnable()
    {
    }
    public void SetActiveTray(bool value,GameObject emplooyer)
    {
        CheckName(emplooyer);
    }
    public void SetTrayActiviness(bool value)
    {
        tray.SetActive(value);
    }

    public void SetCircleAndDrinkState(GameObject barrol)
    {
        circleEmployeeCommand.SetDrinkStates(barrol.name);
        circleEmployeeCommand.Execute();
        SetBottleColor();
    }
    public void SetBottleColor()
    {
        _drinkImages.sprite = _drinkSprites[(int)CurrentColor];
        _drinkRenderer.material.SetColor("_Color", Color);
    }
    private void CheckName(GameObject employeer)
    {
        if(emplooyerName != employeer.name)
        {
            return;
        }
    }
    public void settasd(int value)
    {
        _drinkImages.sprite = _drinkSprites[value];
        CurrentColor = DrinkStates.Null;
        BlueDrink = 0;
        RedDrink = 0;
        YellowDrink = 0;
        WhiteDrink = 0;
        Color = Color.black;
        EarnMoneyFromDrink = 0;
    }

    public void SetNullCircleAndDrink()
    {
        circleEmployeeCommand.SetNull();
    }
}
