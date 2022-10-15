using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeePhysicsController : MonoBehaviour
{
    Employee _employee;
    AnimationController _animationController;
    EmployeeTrayManager eTrayManager;

    private void Awake()
    {
        _employee = GetComponent<Employee>();
        _animationController = GetComponent<AnimationController>();
        eTrayManager = GetComponentInChildren<EmployeeTrayManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("barrolLayer"))
        {
            _employee.FillDrink();
            _animationController.ChangePlayerAnimation(PlayerAnimationStates.FillUp);
            //EmployeeSignals.Instance.onEmployeeTrayActive?.Invoke(true, this.gameObject);
            eTrayManager.SetTrayActiviness(true);
            //EmployeeSignals.Instance.onSetCircleColor?.Invoke(other.gameObject, this.gameObject);
            eTrayManager.SetCircleAndDrinkState(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("barrolLayer"))
        {
            _animationController.ChangePlayerAnimation(PlayerAnimationStates.ServingRunning);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("customerTag"))
        {
            if(collision.gameObject == _employee.target)
            {
                FindObjectOfType<AudioManager>().Play("OrderCompleteSound");
                UISignals.Instance.onMoneyChange?.Invoke(eTrayManager.EarnMoneyFromDrink);
                collision.gameObject.SetActive(false);
                _employee.AllNull();
                eTrayManager.SetNullCircleAndDrink();
                _animationController.ChangePlayerAnimation(PlayerAnimationStates.Running);
                CustomerSignals.Instance.onDeskNull?.Invoke();
                eTrayManager.SetTrayActiviness(false);
            }
        }
    }


}
