using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDeskManager : MonoBehaviour
{
    [SerializeField] private GameObject[] unitGameObject;
    float timer = 0;
    int costPerSecond = 50;

    private void Awake()
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
            BuySignals.Instance.onCost?.Invoke(costPerSecond);
            UISignals.Instance.onMoneyChange(-costPerSecond);
            if (deskObject.transform.GetComponent<SaveableObjectInfo>().BuyDeskCost <= 0)
            {
                deskObject.transform.GetChild(0).transform.gameObject.SetActive(true);
                deskObject.transform.GetChild(0).transform.position = new Vector3(deskObject.transform.position.x, 0, deskObject.transform.position.z);
                BuySignals.Instance.onSaveDesk?.Invoke(deskObject);
                Destroy(deskObject.transform.GetChild(1).gameObject);
                //UISignals.Instance.onMoneyChange?.Invoke(-deskObject.transform.GetComponent<SaveableObjectInfo>().BuyDeskCost);
                deskObject.layer = default;
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
        SetLayer(deskObject);
        Destroy(deskObject.transform.GetChild(1).gameObject);
    }

    private void LoadDesks()
    {
        // Load

        string saveString = SaveSystem.GetData(SaveSystem.BoughtDeskData);

        if (saveString != null)
        {
            char[] separatores = { ',', ';', '|', '{', '}', ':' };
            string[] strValues = saveString.Split(separatores);
            List<int> IDlist = new List<int>();
            string ass = saveString.ToString();
            foreach (string str in strValues)
            {
                int val = 0;
                if (int.TryParse(str, out val))
                {
                    IDlist.Add(val);
                }
            }
            foreach (int item in IDlist)
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
        else
        {
            Debug.Log("nothing awake");
        }
    }

    private void SetLayer(GameObject go)
    {
        go.layer = default;
    }
}
