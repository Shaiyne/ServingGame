using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] GameObject activinessWall;

    private void OnEnable()
    {
        RoomSignals.Instance.onActivinessWall += ActivinessWall;
    }

    private void ActivinessWall(bool value)
    {
        activinessWall.SetActive(value);
    }
}
