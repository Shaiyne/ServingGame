using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlayerCommand : ColorSetting
{
    TrayController TrayController;
    public ColorPlayerCommand(TrayController tc)
    {
        TrayController = tc;
    }
    public void SetDrinkStates(string value)
    {
        ToDrinkStates(value);
    }
    public void Execute()
    {
        TrayController.BlueDrink = BlueDrink;
        TrayController.RedDrink = RedDrink;
        TrayController.YellowDrink = YellowDrink;
        TrayController.WhiteDrink = WhiteDrink;
        TrayController.EarnMoneyFromDrink = EarnMoneyFromDrink;
        TrayController.CurrentColor =  CurrentColor;
        TrayController.Color = Color;
    }
    public void SetNullAll()
    {
        BlueDrink = 0;
        RedDrink = 0;
        YellowDrink = 0;
        WhiteDrink = 0;
        EarnMoneyFromDrink = 0;
        CurrentColor = DrinkStates.Null;
        Color = Color.black;
    }
}
