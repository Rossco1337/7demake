using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour {
    public Text party1Name, party2Name, party3Name;
    public Text party1CurHP, party1MaxHP;
    public Healthbar party1HealthBar, party1ATB;

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
                party1HealthBar.health = unit.currentHP;
                party1CurHP.text = unit.currentHP.ToString ();
                party1MaxHP.text = unit.maxHP.ToString ();
                party1HealthBar.maximumHealth = unit.maxHP;
                party1HealthBar.minimumHealth = 0;

                //i can't get the colours working but it would be nice 
                // party1HealthBar.highHealth = unit.maxHP - 30;
                // party1HealthBar.lowHealth = unit.maxHP / 8;

            }
    }

    private void updateTurnTimers (List<Unit> party) {
        foreach (Unit unit in party) {
            //if (unit.turnTimer != party1ATB.value)
        }
    }
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}