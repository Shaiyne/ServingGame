using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Servingame.Abstracts.UI;

public class CustomerRequestUI : MonoBehaviour , ICustomerRequestUI
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite[] sprites;

    public int BottleColorInt { get; set; }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    public void SetRequestUI(DrinkStates drinkStates)
    {
        switch (drinkStates)
        {
            case DrinkStates.Blue:
                BottleColorInt = 0;
                break;
            case DrinkStates.Red:
                BottleColorInt = 1;
                break;
            case DrinkStates.Yellow:
                BottleColorInt = 2;
                break;
            case DrinkStates.White:
                BottleColorInt = 3;
                break;
            case DrinkStates.GreenMixed:
                BottleColorInt = 4;
                break;
            case DrinkStates.OrangeMixed:
                BottleColorInt = 5;
                break;
            case DrinkStates.PurpleMixed:
                BottleColorInt = 6;
                break;
            case DrinkStates.CyanMixed:
                BottleColorInt = 7;
                break;
        }
        sr.sprite = sprites[this.BottleColorInt];
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        transform.localPosition = new Vector3(0, 6f, 0);
        this.transform.rotation = Quaternion.Euler(30, 0, 0);

    }
}


