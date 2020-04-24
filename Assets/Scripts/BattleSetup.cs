using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Encounter;
public class BattleSetup : MonoBehaviour {
    BattleState bs = new BattleState ();
    Encounter demoEncounter = new Encounter ();

    public void Awake () {
        demoEncounter.reference = 1;
        demoEncounter.isBoss = false;
        Console.AddCommands ();
        SetupField (demoEncounter, "Normal", true);
        SetupTimers ();
    }
    private void SetupField (Encounter encounter, string tempFormation, bool canRun) {
        //TODO pass formation as enum, it's calculated outside battle though so can't declare here yet
        Debug.Log ($"Encounter ID { encounter.reference }, boss {encounter.isBoss}\n Attack type {tempFormation}, canRun { canRun }");
    }

    private void SetupTimers () {
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