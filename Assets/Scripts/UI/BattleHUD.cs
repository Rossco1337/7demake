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
                party1Name.text = unit.playerStats.UnitName;
            }
        }
    }

    private void InitHP (List<Unit> party) {
        foreach (Unit unit in party)
            if (unit != null) {
                //TODO add position identifier for party members
                party1HealthBar.health = unit.currentHP;
                party1CurHP.text = PlayerSave.LoadInt("Player0", "CurrentHp").ToString();
                party1MaxHP.text = PlayerSave.LoadInt("Player0", "MaxHp").ToString();
                party1HealthBar.maximumHealth = PlayerSave.LoadInt("Player0", "MaxHp");
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