using Servingame.Controllers;
using Servingame.Movements;
using System;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public PlayerData PlayerData = new PlayerData();

    public CameraData CameraData = new CameraData();

    public UpgradeData UpgradeData = new UpgradeData();

    public MoneyData MoneyData = new MoneyData();

    public DeskData DeskData = new DeskData();

    public HRData HRData = new HRData();
}
