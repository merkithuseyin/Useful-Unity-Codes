// saves/loads data from previously created GameManager singleton
// https://docs.unity3d.com/ScriptReference/PlayerPrefs.html

using System;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGameData()
    {
        PlayerPrefs.SetInt("MyInt", GameManager.Instance.myInt);
        PlayerPrefs.SetString("DateTime", GameManager.Instance.myDateTime.ToString("s")); //e.g. 2008-10-01T17:04:32
        PlayerPrefs.Save();
    }

    public static void LoadGameData()
    {
        GameManager.Instance.level = PlayerPrefs.GetInt("MyInt");
        GameManager.Instance.myDateTime = DateTime.ParseExact(PlayerPrefs.GetString("DateTime"), "s", System.Globalization.CultureInfo.InvariantCulture);
    }
}