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
    private MovementCommand _horizontalCommand;
    private GameStates _currentState = GameStates.Runner;
    [SerializeField] private bool _isReadyToMove;

    private void Awake()
    {
        touchControls = new TouchControls();
        _horizontalCommand = new MovementCommand();
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
        if(_currentState== GameStates.Runner)
        {
            _horizontalCommand.MovementCommandUpdate(touchControls);
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


}
