using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Servingame.Controllers;

public class PlayerManager : MonoBehaviour
{
    PlayerController _playerController;
    public GameStates CurrentGameStates;
    PlayerAnimationController _playerAnimationController;
    InputManager _inputManager;
    TrayController _trayController;
    TrayManager _trayManager;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        _trayController = GameObject.Find("TrayManager").GetComponent<TrayController>();
        _trayManager = GameObject.Find("TrayManager").GetComponent<TrayManager>();
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
        InputSignals.Instance.onAnimationInputState += ToChangeAnimation;
        PlayerSignals.Instance.onCompareColor += CompareDrinkToRequest;
        CoreGameSignals.Instance.onGamePause += GamePause;
        CoreGameSignals.Instance.onGamePlay += GamePlay;
    }

    void DesubsribeEvents()
    {
        InputSignals.Instance.onInputTaken -= onActiveMovement;
        InputSignals.Instance.onRunnerInputDragged -= OnGetRunnerInputValues;
        InputSignals.Instance.onAnimationInputState -= ToChangeAnimation;
        PlayerSignals.Instance.onCompareColor -= CompareDrinkToRequest;
    }
    private void onActiveMovement()
    {
        _playerController.EnableMovement();
    }

    private void OnGetRunnerInputValues(RunnerInputParams runnerInputParams)
    {
        _playerController.UpdateRunnerInputValue(runnerInputParams);
    }

    private void onDeactiveMovement()
    {
        _playerController.DisableMovement();
        _playerController.SetRunnerInputValue(0, 0);
    }

    public void ToChangeAnimation(PlayerAnimationStates playerAnimationStates)
    {
        _playerAnimationController.ChangePlayerAnimation(playerAnimationStates);
        _inputManager.GetPlayerState(playerAnimationStates);
    }

    public void CompareDrinkToRequest(GameObject customerObject)
    {
        //_trayController.CompareRequest(drinkStates);
        _trayManager.CompareRequest(customerObject);
        _trayManager.SetPlayerDrinkUI();
    }

    public void GamePause()
    {
        _playerController.DisableMovement();
    }

    public void GamePlay()
    {
        _playerController.EnableMovement();
    }
}
