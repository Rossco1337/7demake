using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour {
    public Text party1Name, party2Name, party3Name;
    public Text party1CurHP, party1MaxHP;
    public Healthbar party1HealthBar;

    public void Initialise (List<Unit> party) {

        InitNames (party);
        InitHP (party);

    }
    private void InitNames (List<Unit> party) {
        foreach (Unit unit in party) {
            if (unit != null) {
                //TODO add position identifier for party members
                party1Name.text = unit.unitName;
            }
        }
    }

    private void InitHP (List<Unit> party) {
        foreach (Unit unit in party)
            if (unit != null) {
                //TODO add position identifier for party members
                party1CurHP.text = unit.currentHP.ToString ();
                party1MaxHP.text = unit.maxHP.ToString ();
                party1HealthBar.maximumHealth = unit.maxHP;
                party1HealthBar.minimumHealth = 0;
                party1HealthBar.health = unit.currentHP;
            }
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}