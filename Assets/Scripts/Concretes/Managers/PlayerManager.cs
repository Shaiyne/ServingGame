using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Servingame.Controllers;

public class PlayerManager : MonoBehaviour
{
    PlayerController _playerController;
    public GameStates CurrentGameStates;
    AnimationController _playerAnimationController;
    InputManager _inputManager;
    TrayManager _trayManager;
    PlayerSaveData _playerSaveData;
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerAnimationController = GetComponent<AnimationController>();
        _inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        _trayManager = GameObject.Find("TrayManager").GetComponent<TrayManager>();
        _playerSaveData = GetComponent<PlayerSaveData>();
        _playerSaveData.LoadPlayerTransform();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        DesubsribeEvents();
    }

    void SubscribeEvents()
    {
        InputSignals.Instance.onInputTaken += onActiveMovement;
        InputSignals.Instance.onRunnerInputDragged += OnGetRunnerInputValues;
        InputSignals.Instance.onAnimationInputState += ToChangeAnimation;
        PlayerSignals.Instance.onCompareColor += CompareDrinkToRequest;
        CoreGameSignals.Instance.onPlay += onPlay;
        CoreGameSignals.Instance.onGamePlay += onActiveMovement;
        CoreGameSignals.Instance.onGamePause += onDeactiveMovement;
        CoreGameSignals.Instance.onPause += OnPause;
        CoreGameSignals.Instance.onQuit += OnQuit;
    }

    void DesubsribeEvents()
    {
        InputSignals.Instance.onInputTaken -= onActiveMovement;
        InputSignals.Instance.onRunnerInputDragged -= OnGetRunnerInputValues;
        InputSignals.Instance.onAnimationInputState -= ToChangeAnimation;
        PlayerSignals.Instance.onCompareColor -= CompareDrinkToRequest;
        CoreGameSignals.Instance.onGamePlay -= onPlay;
        CoreGameSignals.Instance.onGamePause -= OnPause;
        CoreGameSignals.Instance.onGameQuit -= OnQuit;
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
        _trayManager.CompareRequest(customerObject);
    }
    public void onPlay()
    {
        _playerController.IsReadyToPlay(true);
        _playerController.EnableMovement();
        _playerSaveData.LoadPlayerTransform();
    }

    public void OnPause()
    {
        _playerController.DisableMovement();
        _playerSaveData.SavePlayerTransform();
    }


    public void OnQuit()
    {
        _playerSaveData.SavePlayerTransform();
    }
}
