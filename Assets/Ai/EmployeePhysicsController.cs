using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeePhysicsController : MonoBehaviour
{
    Employee _employee;
    AnimationController _animationController;

    private void Awake()
    {
        _employee = GetComponent<Employee>();
        _animationController = GetComponent<AnimationController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("barrolLayer"))
        {
            _employee.FillDrink();
            _animationController.ChangePlayerAnimation(PlayerAnimationStates.FillUp);
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
                collision.gameObject.SetActive(false);
                _employee.AllNull();
                _animationController.ChangePlayerAnimation(PlayerAnimationStates.Running);
                CustomerSignals.Instance.onDeskNull?.Invoke();
            }
        }
    }


}
