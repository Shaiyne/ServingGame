using SaveLoadSystem;
using Servingame.Controllers;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
    public GameObject target;
    [SerializeField]GameObject bottleTarget1;
    [SerializeField]GameObject bottleTarget2;
    NavMeshAgent meshAgent;
    GameObject[] customers;
    [SerializeField]DrinkStates drinkStates;
    [SerializeField] bool isMissionActive = false;
    [SerializeField] public int employeeID;
    [SerializeField] int customerID;
    UpgradeData upgrade;
    public float Bottle;
    AnimationController _animationController;
    public EmployeeTrayManager employeeTrayManager;
    int circleColor;
    GameObject blueBarrol;
    GameObject redBarrol;
    GameObject yellowBarrol;
    GameObject whiteBarrol;

    private void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        _animationController = GetComponent<AnimationController>();
        employeeTrayManager = GetComponentInChildren<EmployeeTrayManager>();
        customerID = employeeID;
        blueBarrol = GameObject.FindGameObjectWithTag("blueTag");
        redBarrol = GameObject.FindGameObjectWithTag("redTag");
        yellowBarrol = GameObject.FindGameObjectWithTag("yellowTag");
        whiteBarrol = GameObject.FindGameObjectWithTag("whiteTag");
    }

    private void Start()
    {
        _animationController.ChangePlayerAnimation(PlayerAnimationStates.Running);
        CheckMission();
    }

    private void OnEnable()
    {
        EmployeeSignals.Instance.onCheckNewMission = CheckMission;
    }
    private void Update()
    {
        if (target != null && target.activeInHierarchy) // target.activeInHierarch if player give the order
        {
            if (bottleTarget2 != null)
            {
                meshAgent.SetDestination(bottleTarget1.transform.GetChild(employeeID).position);
                if (Bottle > 30)
                {
                    meshAgent.SetDestination(bottleTarget2.transform.GetChild(employeeID).position);
                    if (Bottle > 100)
                    {
                        meshAgent.SetDestination(target.transform.position);

                    }
                }
            }
            else
            {
                meshAgent.SetDestination(bottleTarget1.transform.GetChild(employeeID).position);
                if (Bottle > 100)
                {
                    meshAgent.SetDestination(target.transform.position);
                    _animationController.ChangePlayerAnimation(PlayerAnimationStates.ServingRunning);
                }
            }

        }
        else if (target == null || !target.activeSelf)
        {
            AllNull();
            CheckMission();
            _animationController.ChangePlayerAnimation(PlayerAnimationStates.Idle);
        }
    }


    private void CompareColor(DrinkStates drinkStates)
    {
        switch (drinkStates)
        {
            case DrinkStates.Blue:
                bottleTarget1 = blueBarrol;
                //circleColor = 1;
                break;
            case DrinkStates.Red:
                bottleTarget1 = redBarrol;
                //circleColor = 2;
                break;
            case DrinkStates.Yellow:
                bottleTarget1 = yellowBarrol;
                //circleColor = 3;
                break;
            case DrinkStates.White:
                bottleTarget1 = whiteBarrol;
                //circleColor = 4;
                break;
            case DrinkStates.GreenMixed:
                bottleTarget1 = blueBarrol;
                bottleTarget2 = yellowBarrol;
                //circleColor = 5;
                break;
            case DrinkStates.OrangeMixed:
                bottleTarget1 = redBarrol;
                bottleTarget2 = yellowBarrol;
                //circleColor = 6;
                break;
            case DrinkStates.PurpleMixed:
                bottleTarget1 = redBarrol;
                bottleTarget2 = blueBarrol;
                //circleColor = 7;
                break;
            case DrinkStates.CyanMixed:
                bottleTarget1 = whiteBarrol;
                bottleTarget2 = blueBarrol;
                //circleColor = 8;
                break;
        }
    }
    public void AllNull()
    {
        drinkStates = DrinkStates.Null;
        target = null;
        bottleTarget1 = null;
        bottleTarget2 = null;
        Bottle = 0;
        isMissionActive = false;
        customerID = employeeID;
        employeeTrayManager.settasd(0);
        CheckMission();
    }

    public void FillDrink()
    {
        upgrade = SaveGameManager.CurrentSaveData.UpgradeData;
        Bottle += 100 * upgrade.ScrollbarSpeed * Time.deltaTime;
        //employeeTrayManager.settasd(circleColor);
    }
    private void CheckMission()
    {
        customers = GameObject.FindGameObjectsWithTag("customerTag");

        if (employeeID < customers.Length)
        {
            if (isMissionActive == false)
            {
                while (customerID < customers.Length)
                {
                    if (customers[customerID].GetComponent<CustomerController>().customerBool == false)
                    {
                        isMissionActive = true;
                        target = customers[customerID];
                        drinkStates = customers[customerID].GetComponent<CustomerController>()._customerRequest;
                        CompareColor(drinkStates);
                        customers[customerID].GetComponent<CustomerController>().customerBool = true;
                        return;
                    }
                    else
                    {
                        Debug.Log("ad");
                        customerID++;
                    }
                }

            }
        }
    }


}
