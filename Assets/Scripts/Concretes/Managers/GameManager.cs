using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameStates _gameStates;
    UpgradeData LevelData;
    private void Awake()
    {
        GameOpen();
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
            CoreGameSignals.Instance.onPlay();
        }
        else if(_gameStates == GameStates.CantMoveSituation)
        {
            CoreGameSignals.Instance.onPause();
        }
    }
    private void SubscribeEvent()
    {
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

}
