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

        sliders[0].value = PlayerSave.LoadInt("Player0", "CurrentHp");
        sliders[1].value = PlayerSave.LoadInt("Player0", "MaxHp");

        //load prefs into text inputs - default to placeholder text
        var inputFields = GetComponentsInChildren<InputField>();
        inputFields[0].text = PlayerSave.LoadString("Player0", "UnitName");
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
        PlayerSave.SaveString("Player0", "UnitName", s.text);
    }
    public void WriteP1CurHp(Slider i)
    {
        PlayerSave.SaveInt("Player0", "CurrentHp", (int)i.value);
    }
    public void WriteP1MaxHP(Slider i)
    {
        PlayerSave.SaveInt("Player0", "MaxHp", (int)i.value);
    }
}
