using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDeskManager : MonoBehaviour
{

    [SerializeField] private GameObject[] Desks;
    int buyingDeskCost = 300;
    private void OnEnable()
    {
        BuySignals.Instance.onBuyDesk += BuyDesk;
    }

    private void BuyDesk(GameObject deskObject)
    {
        if (buyingDeskCost <= PlayerPrefs.GetInt("MoneyData"))
        {
            deskObject.transform.GetChild(0).transform.gameObject.SetActive(true);
            deskObject.transform.GetChild(0).transform.position = new Vector3(deskObject.transform.position.x,0,deskObject.transform.position.z);
            deskObject.transform.GetChild(0).transform.SetParent(null);
            Destroy(deskObject);
            UISignals.Instance.onMoneyChange?.Invoke(-buyingDeskCost);
            buyingDeskCost += 300;
        }
    }
}
