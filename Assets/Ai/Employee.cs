using SaveLoadSystem;
using Servingame.Controllers;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    Animator animator;
    AnimationController _animationController;


    private void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _animationController = GetComponent<AnimationController>();
        customerID = employeeID;
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
                if (Bottle > 50)
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
                bottleTarget1 = GameObject.FindGameObjectWithTag("blueTag");
                break;
            case DrinkStates.Red:
                bottleTarget1 = GameObject.FindGameObjectWithTag("redTag");
                break;
            case DrinkStates.Yellow:
                bottleTarget1 = GameObject.FindGameObjectWithTag("yellowTag");
                break;
            case DrinkStates.White:
                bottleTarget1 = GameObject.FindGameObjectWithTag("whiteTag");
                break;
            case DrinkStates.GreenMixed:
                bottleTarget1 = GameObject.FindGameObjectWithTag("blueTag");
                bottleTarget2 = GameObject.FindGameObjectWithTag("yellowTag");
                break;
            case DrinkStates.OrangeMixed:
                bottleTarget1 = GameObject.FindGameObjectWithTag("redTag");
                bottleTarget2 = GameObject.FindGameObjectWithTag("yellowTag");
                break;
            case DrinkStates.PurpleMixed:
                bottleTarget1 = GameObject.FindGameObjectWithTag("redTag");
                bottleTarget2 = GameObject.FindGameObjectWithTag("blueTag");
                break;
            case DrinkStates.CyanMixed:
                bottleTarget1 = GameObject.FindGameObjectWithTag("whiteTag");
                bottleTarget2 = GameObject.FindGameObjectWithTag("blueTag");
                break;
        }
    }
    public void AllNull()
    {
        drinkStates = DrinkStates.Null;
        target = null;
        bottleTarget1 = null;
        Bottle = 0;
        isMissionActive = false;
        customerID = employeeID;
        CheckMission();
    }

    public void FillDrink()
    {
        upgrade = SaveGameManager.CurrentSaveData.UpgradeData;
        Bottle += 100 * upgrade.ScrollbarSpeed * Time.deltaTime;
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
                        customers[customerID].GetComponent<CustomerController>().customerBool = true;
                        isMissionActive = true;
                        target = customers[customerID];
                        drinkStates = customers[customerID].GetComponent<CustomerController>()._customerRequest;
                        CompareColor(drinkStates);
                        return;
                    }
                    else
                    {
                        customerID++;
                    }
                }

            }
        }
    }
}
