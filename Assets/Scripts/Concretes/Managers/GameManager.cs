using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameStates _gameStates;
    private void Awake()
    {
        OnPlay();
    }
    private void OnEnable()
    {
        SubscribeEvent();
    }
    private void OnDisable()
    {
        DesubscribeEvent();
    }

    private void Update()
    {
        if(_gameStates == GameStates.CanMoveSituation)
        {
            CoreGameSignals.Instance.onGamePlay();
        }
        else if(_gameStates == GameStates.CantMoveSituation)
        {
            CoreGameSignals.Instance.onGamePause();
        }
    }
    private void SubscribeEvent()
    {
        CoreGameSignals.Instance.onPlay += OnPlay;
        CoreGameSignals.Instance.onGamePlay += GameOpen;
        CoreGameSignals.Instance.onGamePause += GamePause;
    }
    private void DesubscribeEvent()
    {
        CoreGameSignals.Instance.onGamePlay -= GameOpen;
        CoreGameSignals.Instance.onGamePause -= GamePause;
    }

    private void GameOpen()
    {
        _gameStates = GameStates.CanMoveSituation;

    }

    private void GamePause()
    {
        _gameStates = GameStates.CantMoveSituation;
    }

    private void OnPlay()
    {
        CoreGameSignals.Instance.onPlay?.Invoke();
    }
    private void OnApplicationQuit()
    {
        CoreGameSignals.Instance.onPause?.Invoke();
        CoreGameSignals.Instance.onQuit?.Invoke();
    }

}
