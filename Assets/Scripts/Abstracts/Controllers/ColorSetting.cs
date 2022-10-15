using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetting : IColors
{
    UpgradeData upgradeData = new UpgradeData();
    public int EarnMoneyFromDrink { get; set; }
    public DrinkStates CurrentColor { get; set; }
    public float RedDrink { get; set; }
    public float BlueDrink { get; set; }
    public float YellowDrink { get; set; }
    public float WhiteDrink { get; set; }
    public Color Color { get; set; }

    public void ToDrinkStates(string barrolColor)
    {
        switch (barrolColor)
        {
            case "blue":
                CurrentColor = DrinkStates.Blue;
                break;
            case "red":
                CurrentColor = DrinkStates.Red;
                break;
            case "yellow":
                CurrentColor = DrinkStates.Yellow;
                break;
            case "white":
                CurrentColor = DrinkStates.White;
                break;
        }
        SetColors(CurrentColor);
    }

    public void SetColors(DrinkStates drinkStates)
    {
        upgradeData = SaveGameManager.CurrentSaveData.UpgradeData;
        switch (drinkStates)
        {
            case DrinkStates.Blue:
                Color = Color.blue;
                CurrentColor = DrinkStates.Blue;
                BlueDrink += 100 * upgradeData.ScrollbarSpeed * Time.deltaTime;
                EarnMoneyFromDrink = 15;
                break;
            case DrinkStates.Red:
                Color = Color.red;
                CurrentColor = DrinkStates.Red;
                RedDrink += 100 * upgradeData.ScrollbarSpeed * Time.deltaTime;
                EarnMoneyFromDrink = 20;
                break;
            case DrinkStates.Yellow:
                Color = Color.yellow;
                CurrentColor = DrinkStates.Yellow;
                YellowDrink += 100 * upgradeData.ScrollbarSpeed * Time.deltaTime;
                EarnMoneyFromDrink = 25;
                break;
            case DrinkStates.White:
                Color = Color.white;
                CurrentColor = DrinkStates.White;
                WhiteDrink += 100 * upgradeData.ScrollbarSpeed * Time.deltaTime;
                EarnMoneyFromDrink = 30;
                break;
        }
        if (BlueDrink >= 100)
        {
            CurrentColor = DrinkStates.Blue;
        }
        else if (RedDrink >= 100)
        {
            CurrentColor = DrinkStates.Red;
        }
        else if (YellowDrink >= 100)
        {
            CurrentColor = DrinkStates.Yellow;
        }
        else if (WhiteDrink >= 100)
        {
            CurrentColor = DrinkStates.White;
        }
        else if (BlueDrink + YellowDrink >= 100)
        {
            CurrentColor = DrinkStates.GreenMixed;
            EarnMoneyFromDrink = 60;
        }
        else if (YellowDrink + RedDrink >= 100)
        {
            CurrentColor = DrinkStates.OrangeMixed;
            EarnMoneyFromDrink = 65;
        }
        else if (BlueDrink + RedDrink >= 100)
        {
            CurrentColor = DrinkStates.PurpleMixed;
            EarnMoneyFromDrink = 70;
        }

        else if (WhiteDrink + BlueDrink >= 100)
        {
            CurrentColor = DrinkStates.CyanMixed;
            EarnMoneyFromDrink = 80;
        }

    }
}
