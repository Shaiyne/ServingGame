using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskController : MonoBehaviour
{
    [SerializeField] GameObject[] _customers;
    private int _customerSize;

    private void Awake()
    {
        SetAvaibleCustomers();
        //DestoryCustomer();
    }
    private void OnEnable()
    {
        CustomerSignals.Instance.onDestroyCustomer += DeleteCustomer;
    }

    //public void SetAvaibleCustomers()
    //{
    //    for(int i = 0; i < UpgradeManager.Instance.CustomersInitializeSize; i++)
    //    {
    //        Instantiate(_customers,new Vector3
    //            (this.gameObject.transform.GetChild(i + 1).position.x,
    //            0.166f,
    //            this.gameObject.transform.GetChild(i + 1).position.z)
    //            , this.gameObject.transform.GetChild(i+1).localRotation).gameObject.transform.SetParent(this.gameObject.transform.GetChild(i+1));
    //    }

    //}


    //public void DestoryCustomer()
    //{
    //    foreach(Transform go in transform)
    //    {
    //        foreach(Transform customer in go)
    //        {
    //            if (customer.gameObject.CompareTag("customerTag"))
    //            {
    //                Destroy(customer.gameObject);
    //            }
    //        }
    //    }
    //}
    public void SetAvaibleCustomers()
    {
        for (int i = 0; i < UpgradeManager.Instance.upgrade.Customers; i++)
        {
            _customers[i].SetActive(true);
        }

    }


    public void DeleteCustomer(GameObject go)
    {
        go.SetActive(false);
    }
}
