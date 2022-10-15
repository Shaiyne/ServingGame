using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEmployeeCommand : ColorSetting
{
    EmployeeTrayManager ETM;
    public ColorEmployeeCommand(EmployeeTrayManager employeeTrayManager)
    {
        ETM = employeeTrayManager;
    }
    public void SetDrinkStates(string value)
    {
        ToDrinkStates(value);
    }

    public void Execute()
    {
        ETM.BlueDrink = BlueDrink;
        ETM.RedDrink = RedDrink;
        ETM.YellowDrink = YellowDrink;
        ETM.WhiteDrink = WhiteDrink;
        ETM.EarnMoneyFromDrink = EarnMoneyFromDrink;
        ETM.CurrentColor = CurrentColor;
        ETM.Color = Color;
    }
    public void SetNull()
    {
        BlueDrink = 0;
        RedDrink = 0;
        YellowDrink = 0;
        WhiteDrink = 0;
        EarnMoneyFromDrink = 0;
        CurrentColor = 0;
        Color = Color.black;
    }
}
