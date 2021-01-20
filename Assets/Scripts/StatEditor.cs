using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatEditor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //load prefs into sliders or default to 0
        var sliders = GetComponentsInChildren<Slider>();
        sliders[0].value = PlayerPrefs.GetInt("p1CurHP", 0);
        sliders[1].value = PlayerPrefs.GetInt("p1MaxHP", 0);

        var inputFields = GetComponentsInChildren<InputField>();
        inputFields[0].text = PlayerPrefs.GetString("p1Name");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteP1Name(InputField s)
    {
        PlayerPrefs.SetString("p1Name", s.text);
    }
    public void WriteP1CurHp(Slider i)
    {
        PlayerPrefs.SetInt("p1CurHP", (int)i.value);

    }
    public void WriteP1MaxHP(Slider i)
    {
        PlayerPrefs.SetInt("p1MaxHP", (int)i.value);
    }
}
