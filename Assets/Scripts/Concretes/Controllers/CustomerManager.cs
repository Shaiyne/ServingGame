using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] GameObject[] _customers;

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
        for (int i = 0; i < SaveSystem.LoadDataInt(SaveSystem.CustomersData); i++)
        {
            _customers[i].SetActive(true);
        }

    }
    private void InitializedCustomers()
    {
        int deactiveCustomer = 0;
        for (int i = 0; i < SaveSystem.LoadDataInt(SaveSystem.CustomersData); i++)
        {
            if (!_customers[i].gameObject.activeSelf)
            {
                deactiveCustomer++;
            }
            if (deactiveCustomer == SaveSystem.LoadDataInt(SaveSystem.CustomersData))
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
