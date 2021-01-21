using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Encounter;
public class BattleSetup : MonoBehaviour {

    //everything declared here is super messy right now and pretty much just for prototype purposes
    public GameObject battleStateObject, battleHUDObject, demoPlayerPrefab, baseEnemyObject;
    public Transform player1BattleStation, enemy1BattleStation;
    public Unit player1Unit, enemy1Unit;
    private BattleHUD battleHUD;
    private BattleState battleState;
    public TextAsset enemyTable;
    public TextAsset encounterTable;
    public List<Unit> partyUnits, enemyUnits;
    public GameObject[] enemyObjects;

    public void Awake () {

        IngameConsole.AddCommands ();
        Encounter demoEncounter = SetupEncounter(encounterTable);
        List<Unit> demoEnemies = SetupEnemies(enemyTable);
        SetupField (demoEncounter, demoEnemies);
        SetupHUD ();
        SetupTimers ();
    }
    private Encounter SetupEncounter (TextAsset encounterTable)
    {
        Encounters encountersInJson = JsonUtility.FromJson<Encounters>(encounterTable.text);

        //pick the first encounter for now
        Encounter demoEncounter = encountersInJson.encounters[0];

        //int enemyCount = demoEncounter.enemies.Length;

        return demoEncounter;
    }

    private List<Unit> SetupEnemies(TextAsset enemyTable)
    {
        Enemies enemiesInJson = JsonUtility.FromJson<Enemies>(enemyTable.text);

        //foreach (string enemyname in demoEncounter.enemies)
        //{
        //    Unit newEnemy = new Unit();
        //    
        //    Debug.Log(enemyname);
        //    foreach (Unit en in enemiesInJson.enemies)
        //    {
        //        
        //
        //        Debug.Log(en.id);
        //        if (en.unitName == enemyname)
        //        {
        //            enemyUnits.Add(en);
        //        }
        //    }
        //            
        //}
        //enemyUnits.Add(new Unit() {})

        List<Unit> demoEnemyList = new List<Unit>();
        Unit demoEnemy = gameObject.AddComponent<Unit>();
        demoEnemy.id = 1337;
        demoEnemy.name = "Enemy1Object";
        demoEnemy.unitName = "Grunty";
        demoEnemy.currentHP = 40;
        demoEnemy.maxHP = 40;
        demoEnemy.sprite = "grunt";
        //demoEnemyList.Add(new Unit () {enemiesInJson.enemies[0] });
        demoEnemyList.Add(demoEnemy);
        demoEnemyList.Add(demoEnemy);

        return demoEnemyList;
    }
    private void SetupField (Encounter encounter, List<Unit> enemyList) {
        //TODO check if fieldtype can even be passed as an enum, not too familiar with json
        Debug.Log ($"Encounter ID { encounter.id }, Setupflag {encounter.setupflag}\n Formation {encounter.formation}, Runchance { encounter.runchance }");

        //##PLAYER
        //TODO saving stats in json. playerprefs works for prototyping.
        GameObject player1Object = Instantiate (demoPlayerPrefab, player1BattleStation);
        player1Unit = player1Object.GetComponent<Unit> ();
        player1Unit.unitName = PlayerPrefs.GetString("p1Name", "NAME_UNSET");
        player1Unit.currentHP = PlayerPrefs.GetInt("p1CurHP", 0);
        player1Unit.maxHP = PlayerPrefs.GetInt("p1MaxHP", 130);
        partyUnits.Add (player1Unit);

        //##ENEMY
        //TODO read enemy data from json as well
        Debug.Log($"Adding {enemyList.Count} enemies");
        for (int i = 0; i < enemyList.Count; i++)
        {
            Debug.Log($"Creating enemy {enemyList[i].unitName} {(i + 1)} with sprite {enemyList[i].sprite}");
            //object
            GameObject enemyObject = Instantiate(demoPlayerPrefab, enemy1BattleStation);
            enemyObject.name = $"Enemy{(i + 1)}";

            //unit data
            Unit enemyUnit = enemyObject.GetComponent<Unit>();
            //enemyUnit = enemyList[i];
            //optimise this. better way of copying in all elements?
            enemyUnit.id = enemyList[i].id;
            enemyUnit.unitName = enemyList[i].unitName;
            enemyUnit.currentHP = enemyList[i].currentHP;
            enemyUnit.maxHP = enemyList[i].maxHP;
            //enemyUnit.sprite = enemyList[i].sprite;
           

            //sprite
            SpriteRenderer enemySpriteR = enemyObject.GetComponent<SpriteRenderer>();
            Sprite enemySprite = Resources.Load<Sprite>($"Sprites/Enemies/{enemyList[i].sprite}");
            enemySpriteR.sprite = enemySprite;


            enemyUnits.Add(enemyUnit);
            Debug.Log($"Added enemy {i + 1} of {enemyList.Count}");
        }
            //enemyObject[i] = 


        //demoEnemy.unitName = enemyList[0].unitName;
        //demoEnemy.maxHP = enemyList[0].maxHP;
        //Debug.Log($"Enemy name {enemyUnits[0].unitName} maxHP {enemyUnits[0].maxHP} enemylist count {enemyList.Count}");
        //Debug.Log($"{enemyList.Count} enemies with a combined {enemyList}")
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