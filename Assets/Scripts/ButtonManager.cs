using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //this is looking real bare after writing prefmanager
    //if scenemanager could be called from a button, this file wouldn't be required
    //at least until i can think of more functions to put on buttons
    public void ChangeScene(string name)
    {
        Debug.Log($"Loading scene { name }");
        SceneManager.LoadScene(name);
    }
}
