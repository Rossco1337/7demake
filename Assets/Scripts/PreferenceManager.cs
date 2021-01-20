using UnityEngine;

public class PreferenceManager : MonoBehaviour
{
    private void Start()
    {
        LoadPrefs();
    }

    private void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SavePrefs()
    {
        Debug.Log("Saving Prefs");
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        //probably put actual preferences in here instead of stats
    }
    public void PrintPrefs()
    {
        Debug.Log($"PlayerPrefs:");
        Debug.Log($"Player 1 Name: { PlayerPrefs.GetString("p1Name") } ");
        Debug.Log($"Player 1 Current HP: { PlayerPrefs.GetInt("p1CurHP") } ");
        Debug.Log($"Player 1 Max HP: { PlayerPrefs.GetInt("p1MaxHP") } ");
    }
    public void ClearPrefs()
    {
        Debug.Log($"Purging prefs");
        PlayerPrefs.DeleteAll();
    }
}