using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Encounter;
public class BattleSetup : MonoBehaviour {

    //everything declared here is super messy right now and pretty much just for prototype purposes
    public Encounter demoEncounter = new Encounter ();
    public GameObject battleStateObject, battleHUDObject, demoPlayerPrefab, demoEnemyPrefab;
    public Transform player1BattleStation, enemy1BattleStation;
    private Unit player1Unit, enemy1Unit;
    private BattleHUD battleHUD;
    private BattleState battleState;
    public List<Unit> partyUnits, enemyUnits;

    public void Awake () {
        demoEncounter.reference = 1;
        demoEncounter.isBoss = false;
        IngameConsole.AddCommands ();
        SetupField (demoEncounter, "Normal", true);
        SetupHUD ();
        SetupTimers ();
    }
    private void SetupField (Encounter encounter, string tempFormation, bool canRun) {
        //TODO pass formation as enum, it's calculated outside battle though so can't declare here yet
        Debug.Log ($"Encounter ID { encounter.reference }, boss {encounter.isBoss}\n Formation {tempFormation}, canRun { canRun }");

        //TODO saving stats in json. playerprefs works for prototyping.
        GameObject player1Object = Instantiate (demoPlayerPrefab, player1BattleStation);
        player1Unit = player1Object.GetComponent<Unit> ();
        player1Unit.unitName = PlayerPrefs.GetString("p1Name", "NAME_ERROR");
        player1Unit.currentHP = PlayerPrefs.GetInt("p1CurHP", 0);
        player1Unit.maxHP = PlayerPrefs.GetInt("p1MaxHP", 130);
        partyUnits.Add (player1Unit);

        //TODO read enemy data from json as well
        GameObject enemy1Object = Instantiate (demoEnemyPrefab, enemy1BattleStation);
        enemy1Unit = enemy1Object.GetComponent<Unit> ();
        enemyUnits.Add (enemy1Unit);

    }

    private void SetupHUD () {
        battleHUD = battleHUDObject.GetComponent<BattleHUD> ();
        battleHUD.Initialise (partyUnits);
    }
    private void SetupTimers () {
        battleState = battleStateObject.GetComponent<BattleState> ();
        //TODO get battle speed from config
        GlobalTimer.BattleSpeed = 0;

        //Calculate speed value from battle speed
        GlobalTimer.CalcGlobalSpeed ();

        //Setup Party

        //TODO calc normal speed from parties
        //foreach unit in all units on field
        //
        GlobalTimer.CalcNormalSpeed (50);
    }
}