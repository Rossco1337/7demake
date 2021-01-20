using UnityEngine;

public class PreferenceManager : MonoBehaviour
{
    //putting stats in preferences for now for prototyping

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
        //PlayerPrefs.SetInt("player1CurHp", playerStats.p1CurHp);
        //PlayerPrefs.SetInt("player1MaxHp", playerStats.p1MaxHp);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        
    }


}