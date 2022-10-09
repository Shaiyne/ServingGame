using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveableObjectInfo : MonoBehaviour
{
    public int ID;
    [SerializeField]public int BuyDeskCost;
    public int CostPerSecond;

    [SerializeField] TextMeshProUGUI DeskCost ;

    private void Awake()
    {
        CostPerSecond = BuyDeskCost / 4;
        DeskCost.text = "Desk purchase cost = " + BuyDeskCost + ". Wait 2 second to buy"; ;
    }

    public void CurrentBuyDeskCost()
    {
        if (this.BuyDeskCost >= 0)
        {
            this.BuyDeskCost -= CostPerSecond;
        }
    }

}
