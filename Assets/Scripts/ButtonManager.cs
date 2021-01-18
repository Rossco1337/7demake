using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartBattleBtn(string name)
    {
        Debug.Log($"Loading scene { name }");
        SceneManager.LoadScene(name);
    }

    public void SavePrefsBtn(int player1CurHp)
    {
        Debug.Log($"Saving prefs");
        PlayerPrefs.SetInt("player1CurHp", player1CurHp);
        PlayerPrefs.Save();
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
