using SaveLoadSystem;
using Servingame.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDeskManager : MonoBehaviour
{
    [SerializeField] private GameObject[] unitGameObject;
    float timer = 0;
    DeskData _deskData = new DeskData();
    

    private void Awake()
    {
        //LoadDesks();
    }
    private void Start()
    {
        LoadDesks();
    }
    private void OnEnable()
    {
        BuySignals.Instance.onBuyDesk += BuyDesk;
        BuySignals.Instance.onLoadDesk += LoadDesk;
    }

    private void BuyDesk(GameObject deskObject)
    {
        if (timer >= 0.6f)
        {
            if (deskObject.transform.GetComponent<SaveableObjectInfo>().BuyDeskCost == 0)
            {
                LoadDesk(deskObject);
                BuySignals.Instance.onSaveDesk?.Invoke(deskObject);
                SaveDesks(deskObject);
                SaveGameManager.CurrentSaveData.DeskData = _deskData;
                SaveGameManager.SaveGame();
            }
            else if (SaveGameManager.CurrentSaveData.MoneyData.Money >= deskObject.GetComponent<SaveableObjectInfo>().CostPerSecond)
            {
                deskObject.GetComponent<SaveableObjectInfo>().CurrentBuyDeskCost();
                UISignals.Instance.onMoneyChange(-deskObject.transform.GetComponent<SaveableObjectInfo>().CostPerSecond);
            }
            timer = 0;
        }
        else if (timer <= 0.6f) 
        {
            timer += Time.deltaTime;
        }

    }

    private void LoadDesk(GameObject deskObject)
    {
        deskObject.transform.GetChild(0).transform.gameObject.SetActive(true);
        deskObject.transform.GetChild(0).transform.position = new Vector3(deskObject.transform.position.x, 0.1f, deskObject.transform.position.z);
        Destroy(deskObject.transform.GetChild(1).gameObject);
        SetLayer(deskObject);
    }

    private void SaveDesks(GameObject deskObject)
    {
        _deskData.DeskID.Add(deskObject.transform.GetComponent<SaveableObjectInfo>().ID); 
    }
    private void LoadDesks()
    {
        _deskData = SaveGameManager.CurrentSaveData.DeskData;
        if (_deskData.DeskID.Count != 0)
        {
            foreach (int item in _deskData.DeskID)
            {
                for (int i = 0; i < unitGameObject.Length; i++)
                {
                    if (item == unitGameObject[i].GetComponent<SaveableObjectInfo>().ID)
                    {
                        LoadDesk(unitGameObject[i].gameObject);
                        SetLayer(unitGameObject[i].gameObject);
                    }
                }
            }
        }

    }

    private void SetLayer(GameObject go)
    {
        go.layer = default;
    }
}
