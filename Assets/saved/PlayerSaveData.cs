using SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData : MonoBehaviour
{
    private PlayerData MyData = new PlayerData();

    public void SavePlayerTransform()
    {
        var transform1 = transform;
        MyData.PlayerPosition = transform1.position;
        MyData.PlayerRotation = transform1.rotation;
        SaveGameManager.CurrentSaveData.PlayerData = MyData;
        SaveGameManager.SaveGame();
    }
    public void LoadPlayerTransform()
    {
        SaveGameManager.LoadGame();
        MyData = SaveGameManager.CurrentSaveData.PlayerData;
        transform.position = MyData.PlayerPosition;
        transform.rotation = MyData.PlayerRotation;
    }
}
[System.Serializable]
public struct PlayerData
{
    public Vector3 PlayerPosition;
    public Quaternion PlayerRotation;
}
