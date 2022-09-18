using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Servingame.Controllers;

public class PlayerManager : MonoBehaviour
{
    PlayerController _playerController;
    public GameStates CurrentGameStates;
    PlayerAnimationController _playerAnimationController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    private void FixedUpdate()
    {
        
    }
    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        DesubsribeEvents();
    }
    public void OnPlay()
    {
        _playerController.IsReadyToPlay(true);
    }
    void SubscribeEvents()
    {
        InputSignals.Instance.onInputTaken += onActiveMovement;
        InputSignals.Instance.onRunnerInputDragged += OnGetRunnerInputValues;
        InputSignals.Instance.onInputReleased += CheckIsRunning;
    }

    void DesubsribeEvents()
    {
        InputSignals.Instance.onInputTaken -= onActiveMovement;
        InputSignals.Instance.onRunnerInputDragged -= OnGetRunnerInputValues;
        InputSignals.Instance.onInputReleased += CheckIsRunning;
    }
    private void onActiveMovement()
    {
        _playerController.EnableMovement();
        _playerAnimationController.ChangePlayerAnimation(PlayerAnimationStates.Running);
    }

    private void OnGetRunnerInputValues(RunnerInputParams runnerInputParams)
    {
        _playerController.UpdateRunnerInputValue(runnerInputParams);
    }
    private void OnGetIdle()
    {
        _playerAnimationController.ChangePlayerAnimation(PlayerAnimationStates.Idle);
    }


    private void onDeactiveMovement()
    {
        _playerController.DisableMovement();
        _playerController.SetRunnerInputValue(0, 0);
    }

    public void CheckIsRunning()
    {
        _playerAnimationController.ChangePlayerAnimation(PlayerAnimationStates.Idle);
    }
}
