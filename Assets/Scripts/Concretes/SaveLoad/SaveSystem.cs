using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem {

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private const string SAVE_EXTENSION = "txt";
    public static string MoneyData = "save_Money";
    public static string CustomersData = "save_Customers";
    public static string TypeDrinkData = "save_TypeDrink";
    public static string ScrollbarData = "save_Scrollbar";
    public static string CustomersCostData = "save_CustomersCost";
    public static string TypeDrinkCostData = "save_TypeDrinkCost";
    public static string ScrollbarCostData = "save_ScrollbarCost";
    public static string BoughtDeskData = "save_DeskData";

    public static void Init() {
        if (!Directory.Exists(SAVE_FOLDER)) {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void SaveDesks(string saveString)
    {
        if (!File.Exists(SAVE_FOLDER + BoughtDeskData + "." + SAVE_EXTENSION))
        {
            Init();
        }
        File.AppendAllText(SAVE_FOLDER + BoughtDeskData + "." + SAVE_EXTENSION, saveString);

    }
    public static void SaveData(int value,string saveData)
    {
        SaveTheDataInt saveTheData = new SaveTheDataInt
        {
            CurrentInt = value
        };
        string json = JsonUtility.ToJson(saveTheData);
        if (!File.Exists(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION))
        {

            File.AppendAllText(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION, json);
        }
        if(saveData == MoneyData)
        {
            int current = JsonDataToInt(saveData) + value;
            string deneCure = current.ToString();
            File.Delete(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION);
            File.AppendAllText(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION, deneCure);
        }
        else
        {
            string custo = value.ToString();
            File.Delete(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION);
            File.AppendAllText(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION, custo);
        }

    }
    public static void SaveDataFloat(float value, string saveData)
    {

        SaveTheDataFloat saveTheData = new SaveTheDataFloat
        {
            CurrentFloat = value
        };
        string json = JsonUtility.ToJson(saveTheData);
        if (!File.Exists(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION))
        {
            string currentJson = value.ToString();
            File.AppendAllText(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION, currentJson);
        }

        else
        {
            string currentJson = value.ToString();
            File.Delete(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION);
            File.AppendAllText(SAVE_FOLDER + saveData + "." + SAVE_EXTENSION, currentJson);
        }


    }
    public static string GetData(string txtFile)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] abc = directoryInfo.GetFiles("*." + SAVE_EXTENSION);
        FileInfo currentFile = null;
        foreach (FileInfo item in abc)
        {
            if (item.Name == txtFile + ".txt")
            {
                currentFile = item;
            }
        }
        if (currentFile != null)
        {
            string deneme = File.ReadAllText(currentFile.ToString());
            return deneme;
        }
        else return null;

    }
    public static int LoadDataInt(string Data)
    {
        if (Data != null)
        {
            int GetDataint = int.Parse(GetData(Data));
            return GetDataint;
        }
        else return 0;

    }
    public static float LoadDataFloat(string Data)
    {
        float GetDataFloat = float.Parse(SaveSystem.GetData(Data));
        return GetDataFloat;
    }

    public static int JsonDataToInt(string txtFile)
    {
        // Load
        int Count = 0;
        string saveString = SaveSystem.GetData(txtFile);

        if (saveString != null)
        {
            char[] separatores = { ',', ';', '|', '{', '}', ':' };
            string[] strValues = saveString.Split(separatores);
            string ass = saveString.ToString();
            foreach (string str in strValues)
            {
                int val = 0;
                if (int.TryParse(str, out val))
                {
                    Count = val;
                }
            }
        }

        return Count;
    }
    public static float JsonDataToFloat(string txtFile)
    {
        // Load
        float Count = 0;
        string saveString = SaveSystem.GetData(txtFile);

        if (saveString != null)
        {
            char[] separatores = { ',', ';', '|', '{', '}', ':' };
            string[] strValues = saveString.Split(separatores);
            string ass = saveString.ToString();
            foreach (string str in strValues)
            {
                float val = 0;
                if (float.TryParse(str, out val))
                {
                    Count = val;
                    Debug.Log(val);
                }
            }
        }

        return Count;
    }

    private class SaveTheDataInt
    {
        public int CurrentInt;
    }
    private class SaveTheDataFloat
    {
        public float CurrentFloat;
    }
}
