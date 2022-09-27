using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]

public class InputManager : Singleton<InputManager>
{
    public delegate void StartTouchHEvent(float value);
    public event StartTouchHEvent OnStartTouchH;
    public delegate void StartTouchVEvent(float value);
    public event StartTouchVEvent OnStartTouchV;

    private TouchControls touchControls;
    private MovementEmptyCommand _emptyCommand;
    private MovementServingCommand _servingCommand;
    private GameStates _currentState = GameStates.CanMoveSituation;
    private PlayerAnimationStates PlayerAnimationStates;
    [SerializeField] private bool _isReadyToMove;

    private void Awake()
    {
        touchControls = new TouchControls();
        _emptyCommand = new MovementEmptyCommand();
        _servingCommand = new MovementServingCommand();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        SubscribeEvents();
    }
    private void OnDisable()
    {
        touchControls.Disable();
        DisubscribeEvents();
    }
    private void Update()
    {
        if(_currentState == GameStates.CanMoveSituation)
        {
            //_emptyCommand.MovementEmptyCommandUpdate(touchControls);
            if(PlayerAnimationStates == PlayerAnimationStates.FillUp)
            {
                _servingCommand.MovementFillUpCommandUpdate(touchControls);
            }
            else if (PlayerAnimationStates == PlayerAnimationStates.ServingIdle || PlayerAnimationStates == PlayerAnimationStates.ServingRunning)
            {
                _servingCommand.MovementServingCommandUpdate(touchControls);
            }
            else if(PlayerAnimationStates == PlayerAnimationStates.Idle || PlayerAnimationStates == PlayerAnimationStates.Running)
            {
                _emptyCommand.MovementEmptyCommandUpdate(touchControls);
            }
        }
    }

    private void SubscribeEvents()
    {
        InputSignals.Instance.onEnableInput += OnEnableInput;
        InputSignals.Instance.onDisableInput += OnDisableInput;
        touchControls.Touch.TouchH.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchV.started += ctx => StartTouch(ctx);
    }
    private void DisubscribeEvents()
    {
        InputSignals.Instance.onEnableInput -= OnEnableInput;
        InputSignals.Instance.onDisableInput -= OnDisableInput;
        touchControls.Touch.TouchH.started -= ctx => StartTouch(ctx);
        touchControls.Touch.TouchV.started -= ctx => StartTouch(ctx);
    }

    void StartTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouchH != null) OnStartTouchH(touchControls.Touch.TouchH.ReadValue<float>());
        if (OnStartTouchV != null) OnStartTouchV(touchControls.Touch.TouchV.ReadValue<float>());
    }

    private void OnEnableInput()
    {
        _isReadyToMove = true;
    }
    private void OnDisableInput()
    {
        _isReadyToMove = false;
    }

    public void GetPlayerState(PlayerAnimationStates playerAnimationStates)
    {
        PlayerAnimationStates = playerAnimationStates;
    }
}
