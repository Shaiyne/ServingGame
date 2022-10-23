using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveLoadSystem
{
    public static class SaveGameManager
    {
        public static SaveData CurrentSaveData = new SaveData();


        public const string SaveDirectory = "/Saves/";

        public const string FileName = "SaveData.sav";

        //public const string CameraDataName = "CameraSaveData.sav";

        public static bool SaveGame()
        {
            var dir = Application.persistentDataPath + SaveDirectory;

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (!File.Exists(dir + FileName))
            {
                CurrentSaveData.CameraData.CameraPosition = new Vector3(-1.1265778f, 10.5f, -5.83f);
                CurrentSaveData.CameraData.CameraRotation = Quaternion.Euler(58.6061325f, -2f, 358.676636f);
                CurrentSaveData.PlayerData.PlayerPosition = new Vector3(-1, 0, 0);
                CurrentSaveData.PlayerData.PlayerRotation = Quaternion.Euler(0, 0, 0);
                CurrentSaveData.UpgradeData.CustomerSize = 1;
                CurrentSaveData.UpgradeData.TypeDrinkSize = 3;
                CurrentSaveData.UpgradeData.ScrollbarSpeed = 0.1f;
                CurrentSaveData.UpgradeData.CustomerCost = 100;
                CurrentSaveData.UpgradeData.TypeDrinkCost = 300;
                CurrentSaveData.UpgradeData.ScrollbarSpeedCost = 100;
                CurrentSaveData.MoneyData.Money = 300;
                CurrentSaveData.HRData.EmployeeBuyCost = 300;
                CurrentSaveData.HRData.EmployeeID = null;
                
            }
            string json = JsonUtility.ToJson(CurrentSaveData, true);
            File.WriteAllText(dir + FileName, json);

            GUIUtility.systemCopyBuffer = dir;
            return true;
        }
        public static void LoadGame()
        {
            var dir = Application.persistentDataPath + SaveDirectory;
            if (!File.Exists(dir + FileName))
            {
                SaveGame();
            }
            string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
            SaveData tempData = new SaveData();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                tempData = JsonUtility.FromJson<SaveData>(json);
            }
            else
            {
                Debug.Log("Save file does not exists");
            }
            CurrentSaveData = tempData;
        }
        public static void NewGameSave()
        {
            var dir = Application.persistentDataPath + SaveDirectory;
            if (Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(dir + FileName))
            {
                File.Delete(dir + FileName);

            }
        }
    }

}
