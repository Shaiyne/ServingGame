using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public FloatingJoystick floatingJoystick;
    public GameObject JoystickActiviness;
    AnimationController _playerAnimationController;
    InputManager _inputManager;
    public float speed;
    public float turnSpeed;
    private void Awake()
    {
        _playerAnimationController = GetComponent<AnimationController>();
        _inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
    }
    private void OnEnable()
    {
        CoreGameSignals.Instance.onGamePlay += ActiveMovement;
        CoreGameSignals.Instance.onGamePause += DeactiveMovement;
        InputSignals.Instance.onAnimationInputState += ChangingAnimationState;
    }
    private void FixedUpdate()
    {
        if (floatingJoystick.gameObject.activeInHierarchy)
        {
            if (Input.GetButton("Fire1"))
            {
                JoystickMovement();
            }
        }
    }

    public void JoystickMovement()
    {
        float horizontal = floatingJoystick.Horizontal;
        float vertical = floatingJoystick.Vertical;
        Vector3 addedPos = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);
        transform.position += addedPos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
    }
    public void ActiveMovement()
    {
        JoystickActiviness.SetActive(true);
    }

    public void DeactiveMovement()
    {
        JoystickActiviness.SetActive(false);
    }

    public void ChangingAnimationState(PlayerAnimationStates playerAnimationStates)
    {
        _playerAnimationController.ChangePlayerAnimation(playerAnimationStates);
        _inputManager.GetPlayerState(playerAnimationStates);
    }
}
