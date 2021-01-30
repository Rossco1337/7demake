using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BattleSetup : MonoBehaviour {

    //everything declared here is super messy right now and pretty much just for prototype purposes
    public GameObject battleStateObject, battleHUDObject, baseUnitPrefab;
    public Transform player1BattleStation;
    public Transform[] enemyBattleStations;
    public Actor player1Unit, enemy1Unit;
    private bool useEnemyJson = false; 
    private BattleHUD battleHUD;
    private BattleState battleState;
    public TextAsset enemyTable;
    public TextAsset encounterTable;
    public List<EnemyStats> enemyUnits;
    public List<Actor> partyUnits;
    public List<GameObject> enemyObjects;

    public void Awake () {

        IngameConsole.AddCommands ();
        Encounter demoEncounter = SetupEncounter(encounterTable);
        SetupEnemies (enemyTable, demoEncounter);
        SetupField (demoEncounter, enemyUnits);
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

    private void SetupEnemies(TextAsset enemyTable, Encounter encounter)
    {
        if (useEnemyJson)
        {
            Enemies enemiesInJson = JsonUtility.FromJson<Enemies>(enemyTable.text);
            int encounterEnemyCount = encounter.enemies.Length;
            Debug.Log($"Enemy Table: {enemiesInJson.enemies.Length} enemies loaded.");
            Debug.Log($"Enemies: {enemiesInJson.enemies[0]}");

            foreach (string enemyName in encounter.enemies)
            {
                Debug.Log($"ENEMY: {enemyName}");

            }

            for (int i = 0; i < encounterEnemyCount; i++)
            {

                Debug.Log($"Adding Enemy {i + 1} of {encounterEnemyCount}");
                //foreach (Actor enemy in enemiesInJson.enemies)
                {
                    //Debug.Log($"Checking if {enemy.actorName}");
                    //if (encounter.enemies[i] == enemy.actorName) {
                    //enemyUnits.Add(enemy);
                    //}
                }
            }


            //foreach (string enemyname in demoEncounter.enemies)
            //{
            //    Actor newEnemy = new Actor();
            //    
            //    Debug.Log(enemyname);
            //    foreach (Actor en in enemiesInJson.enemies)
            //    {
            //        
            //
            //        Debug.Log(en.id);
            //        if (en.actorName == enemyname)
            //        {
            //            enemyUnits.Add(en);
            //        }
            //    }
            //            
            //}
            //enemyUnits.Add(new Actor() {})

            //##Manually adding enemies
            //List<Actor> demoEnemyList = new List<Actor>();
            //Actor demoEnemy = gameObject.AddComponent<Actor>();
            //demoEnemy.id = 1337;
            //demoEnemy.name = "Enemy1Object";
            //demoEnemy.actorName = "Grunty";
            //demoEnemy.currentHP = 40;
            //demoEnemy.maxHP = 40;
            //demoEnemy.sprite = "grunt";
            ////demoEnemyList.Add(new Actor () {enemiesInJson.enemies[0] });
            //enemyUnits.Add(demoEnemy);
            //enemyUnits.Add(demoEnemy);
        }
        else
        {
            foreach (string enemyName in encounter.enemies)
            {
                Debug.Log($"Loading Enemy: {enemyName}");
                GameObject enemyObject;
                try
                {
                    enemyObject = Resources.Load($"Enemies/{enemyName}") as GameObject;
                    Debug.Assert(enemyObject.name == enemyName);
                    Debug.Log($"Enemy {enemyName} load OK!");
                }
                catch
                {
                    Debug.LogWarning($"Loading prefab enemy {enemyName} failed! Falling back to Test0.");
                    enemyObject = Resources.Load($"Enemies/baseEnemy") as GameObject;
                }
                enemyObjects.Add(enemyObject);
            }
        }
    }
    private void SetupField(Encounter encounter, List<EnemyStats> enemyList)
    {
        //TODO check if fieldtype can even be passed as an enum, not too familiar with json
        Debug.Log ($"Encounter ID { encounter.id }, Setupflag {encounter.setupflag}\n Formation {encounter.formation}, Runchance { encounter.runchance }");

        //##PLAYER
        //TODO saving stats in json. playerprefs works for prototyping.
        GameObject player1Object = Instantiate (baseUnitPrefab, player1BattleStation);
        player1Unit = player1Object.GetComponent<Actor> ();
        //player1Unit.actorName = PlayerPrefs.GetString("p1Name", "NAME_UNSET");
        //player1Unit.currentHP = PlayerPrefs.GetInt("p1CurHP", 0);
        //TODO fix this call. actually just fix this whole function once it's working.
        partyUnits.Add (player1Unit);

        //##ENEMY

        if (useEnemyJson)
        {
            //TODO read enemy data from json as well
            Debug.Log($"Adding {enemyList.Count} enemies");
            for (int i = 0; i < enemyList.Count; i++)
            {
                //Debug.Log($"Creating enemy {enemyList[i].actorName} {(i + 1)} with sprite {enemyList[i].sprite}");
                //object

                GameObject enemyObject = Instantiate(baseUnitPrefab, enemyBattleStations[i]);
                enemyObject.name = $"Enemy{(i + 1)}";

                //actor data
                Actor enemyUnit = enemyObject.GetComponent<Actor>();
                //enemyUnit = enemyList[i];
                //optimise this. better way of copying in all elements?
                //enemyUnit = enemyList.CopyTo();
                //enemyUnit.id = enemyList[i].id;

                /*
                enemyUnit.actorName = enemyList[i].actorName;
                enemyUnit.currentHP = enemyList[i].currentHP;
                enemyUnit.maxHP = enemyList[i].maxHP;
                */


                //sprite
                SpriteRenderer enemySpriteR = enemyObject.GetComponent<SpriteRenderer>();

                //Sprite enemySprite = Resources.Load<Sprite>($"Sprites/Enemies/{enemyList[i].sprite}");
                //enemySpriteR.sprite = enemySprite;
                //enable shadow
                EnableShadow(enemyBattleStations[i]);


                //Debug.Log($"Added enemy {i + 1} of {enemyList.Count}");
            }
            //enemyObject[i] = 


            //demoEnemy.actorName = enemyList[0].actorName;
            //demoEnemy.maxHP = enemyList[0].maxHP;
            //Debug.Log($"Enemy name {enemyUnits[0].actorName} maxHP {enemyUnits[0].maxHP} enemylist count {enemyList.Count}");
            //Debug.Log($"{enemyList.Count} enemies with a combined {enemyList}")
        }
        else
        {
            if (enemyObjects.Count == 0)
            {
                Debug.Log("No enemies loaded! Returning to menu.");
                EndBattle();
            }
            else
            {
                for (int i = 0; i < enemyObjects.Count; i++)
                {
                    Debug.Log($"Instantiating {enemyObjects[i].name} into {enemyBattleStations[i]}");
                    GameObject enemyObject = Instantiate(enemyObjects[i], enemyBattleStations[i]);
                    EnableShadow(enemyBattleStations[i]);
                }
            }
        }
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
        //foreach actor in all actors on field
        //
        GlobalTimer.CalcNormalSpeed (50);
    }

    private void EnableShadow (Transform battleStation)
    {
        SpriteRenderer enemyContainerSpriteR = battleStation.GetComponent<SpriteRenderer>();
        enemyContainerSpriteR.enabled = true;
    }

    private void EndBattle ()
    {
        //this is starting to become a general purpose battle management script...
        SceneManager.LoadScene("Menu");
    }
}