using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    PreferenceManager preferenceManager;

    public void StartBattleBtn(string name)
    {
        Debug.Log($"Loading scene { name }");
        SceneManager.LoadScene(name);
    }

    public void SavePrefsBtn()
    {

        Debug.Log($"Saving prefs");
        preferenceManager.SavePrefs();
    }

    public void PrintPrefsBtn()
    {
        Debug.Log($"PlayerPrefs:");
        Debug.Log($"Player 1 Current HP: { PlayerPrefs.GetInt("player1CurHp") } ");
    }

    public void ClearPrefsBtn()
    {
        Debug.Log($"Purging prefs");
        PlayerPrefs.DeleteAll();
    }
}
