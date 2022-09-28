using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public DrinkStates _customerRequest;

    private void Awake()
    {
        _customerRequest = (DrinkStates)Random.Range(0, 4);
    }
}
