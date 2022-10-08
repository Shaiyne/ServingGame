using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveableObjectInfo : MonoBehaviour
{
    public int ID;
    [SerializeField]public int BuyDeskCost;

    [SerializeField] TextMeshProUGUI DeskCost ;

    private void Awake()
    {
        DeskCost.text = "Desk purchase cost = " + BuyDeskCost + ". Wait 2 second to buy"; ;
    }
    private void OnEnable()
    {
        BuySignals.Instance.onCost += CurrentBuyDeskCost;
    }
    private void CurrentBuyDeskCost(int value)
    {
        BuyDeskCost -= value;
    }

}
