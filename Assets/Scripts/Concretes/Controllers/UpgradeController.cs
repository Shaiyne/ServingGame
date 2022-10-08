using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] GameObject activinessWall;

    private void OnEnable()
    {
        UpgradeSignals.Instance.onActivinessWall += ActivinessWall;
    }

    private void ActivinessWall(bool value)
    {
        activinessWall.SetActive(value);
    }
}
