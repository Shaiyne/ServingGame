using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColors
{
    public int EarnMoneyFromDrink { get; set; }
    public DrinkStates CurrentColor { get; set; }
    public float RedDrink { get; set; }
    public float BlueDrink { get; set; }
    public float YellowDrink { get; set; }
    public float WhiteDrink { get; set; }
    public Color Color { get; set; }

}
