using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] GameObject[] _customers;
    UpgradeData upgradeData = new UpgradeData();

    private void OnEnable()
    {
        CustomerSignals.Instance.onDeactiveCustomer += DeactiveCustomer;
        CustomerSignals.Instance.onDeskNull += InitializedCustomers;
    }
    private void OnDisable()
    {
        CustomerSignals.Instance.onDeactiveCustomer -= DeactiveCustomer;
        CustomerSignals.Instance.onDeskNull -= InitializedCustomers;
    }
    private void Start()
    {
        SetAvaibleCustomers();
    }

    public void SetAvaibleCustomers()
    {
        upgradeData = SaveGameManager.CurrentSaveData.UpgradeData;
        for (int i = 0; i < upgradeData.CustomerSize; i++)
        {
            _customers[i].SetActive(true);
        }

    }
    private void InitializedCustomers()
    {
        int deactiveCustomer = 0;
        upgradeData = SaveGameManager.CurrentSaveData.UpgradeData;
        for (int i = 0; i < upgradeData.CustomerSize; i++)
        {
            if (!_customers[i].gameObject.activeSelf)
            {
                deactiveCustomer++;
            }
            if (deactiveCustomer == upgradeData.CustomerSize)
            {
                StartCoroutine(SetActiveCustomerWait());
            }
        }
    }

    private void DeactiveCustomer(GameObject go)
    {
        go.SetActive(false);
    }


    IEnumerator SetActiveCustomerWait()
    {
        yield return new WaitForSecondsRealtime(5);
        SetAvaibleCustomers();
    }
}
