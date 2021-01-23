using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatEditor : MonoBehaviour
{
    void Start()
    {
        //load prefs into sliders or default to 0
        var sliders = GetComponentsInChildren<Slider>();
        sliders[0].value = PlayerPrefs.GetInt("p1CurHP", 0);
        sliders[1].value = PlayerPrefs.GetInt("p1MaxHP", 0);

        //load prefs into text inputs - default to placeholder text
        var inputFields = GetComponentsInChildren<InputField>();
        inputFields[0].text = PlayerPrefs.GetString("p1Name");
    }

    void Update()
    {
        
    }

    //now THIS is functional programming!
    //OnClick and OnChange events can run one function each so this is the easiest way to do this for now.
    //TODO figure out a better way of doing this because otherwise this file is going to get stupid...
    //... even when stats are serialised into json or whatever, this isn't optimal for config
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
