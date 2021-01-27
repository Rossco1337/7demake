using UnityEngine;
public static class PlayerSave
{
    public static void SaveString(string playerName, string stat, string value)
    {
        //save string overload
        string saveString = $"{playerName}-{stat}";
        Debug.Log($"PlayerSave :: Saving {value} to {saveString}");
        PlayerPrefs.SetString(saveString, value);
    }

    public static void SaveInt(string playerName, string stat, int value)
    {
        //save int overload
        string saveString = $"{playerName}-{stat}";
        Debug.Log($"PlayerSave :: Saving {value} to {saveString}");
        PlayerPrefs.SetInt(saveString, value);
    }

    public static string LoadString(string playerName, string stat)
    {
        string loadString = $"{playerName}-{stat}";
        Debug.Log($"PlayerSave :: Loading {loadString}");
        return PlayerPrefs.GetString(loadString, "STRING_LOAD_FAIL");
    }


    public static int LoadInt(string playerName, string stat)
    {
        string loadString = $"{playerName}-{stat}";
        Debug.Log($"PlayerSave :: Loading {loadString}");
        return PlayerPrefs.GetInt(loadString, 6666);
    }
}