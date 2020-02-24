// saves/loads data from previously created GameManager singleton to/from JSON formatted file

using System;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string path = Path.Combine(Application.persistentDataPath, "data.json");
    public static void SaveGameData()
    {
        JsonData data = new JsonData();
        data.GameManagerToJsonDataClass();
        File.WriteAllText(path, JsonUtility.ToJson(data, true));
    }

    public static void LoadGameData()
    {
        if (File.Exists(path))
        {
            JsonData data = JsonUtility.FromJson<JsonData>(File.ReadAllText(path));
            data.JsonDataClassToGameManager();
        }
        else
        {
            Debug.LogError("No file found in " + path);
        }
    }

    [Serializable]
    private class JsonData
    {
        public int myInt;
        public DateTime myDateTime;

        public void GameManagerToJsonDataClass()
        {
            GameManager gm = GameManager.Instance;
            myInt = gm.myInt;
            myDateTime = gm.currentTime;
        }

        public void JsonDataClassToGameManager()
        {
            GameManager gm = GameManager.Instance;
            gm.myInt = myInt;
            gm.currentTime = myDateTime;
        }
    }
}