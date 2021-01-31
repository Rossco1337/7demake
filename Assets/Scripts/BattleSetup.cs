using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSetup : MonoBehaviour
{
    //everything declared here is super messy right now and pretty much just for prototype purposes
    public GameObject battleStateObject, battleHUDObject, baseUnitPrefab;
    public Transform player1BattleStation;
    public Transform[] enemyBattleStations;
    public Actor player1Unit, enemy1Unit;
    public TextAsset encounterTable;
    public List<Actor> partyUnits;
    public List<GameObject> enemyObjects;
    private BattleHUD battleHUD;
    private BattleState battleState;

    public void Awake()
    {
        var demoEncounter = SetupEncounter(encounterTable);
        SetupEnemies(demoEncounter);
        SetupField(demoEncounter);
        SetupHUD();
        SetupTimers();
    }

    private Encounter SetupEncounter(TextAsset encounterTable)
    {
        var encountersInJson = JsonUtility.FromJson<Encounters>(encounterTable.text);

        //pick the first encounter for now
        var demoEncounter = encountersInJson.encounters[0];
        return demoEncounter;
    }

    private void SetupEnemies(Encounter encounter)
    {
        {
            foreach (var enemyName in encounter.enemies)
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
                    enemyObject = Resources.Load("Enemies/baseEnemy") as GameObject;
                }

                enemyObjects.Add(enemyObject);
            }
        }
    }

    private void SetupField(Encounter encounter)
    {
        //TODO check if fieldtype can even be passed as an enum, not too familiar with json
        Debug.Log(
            $"Encounter ID {encounter.id}, Setupflag {encounter.setupflag}\n Formation {encounter.formation}, Runchance {encounter.runchance}");

        //##PLAYER
        //TODO saving stats in json. playerprefs works for prototyping.
        var player1Object = Instantiate(baseUnitPrefab, player1BattleStation);
        player1Unit = player1Object.GetComponent<Actor>();
        //player1Unit.actorName = PlayerPrefs.GetString("p1Name", "NAME_UNSET");
        //player1Unit.currentHp = PlayerPrefs.GetInt("p1CurHP", 0);
        //TODO fix this call. actually just fix this whole function once it's working.
        partyUnits.Add(player1Unit);

        //##ENEMY
        if (enemyObjects.Count == 0)
        {
            Debug.Log("No enemies loaded! Returning to menu.");
            EndBattle();
        }
        else
        {
            for (var i = 0; i < enemyObjects.Count; i++)
            {
                Debug.Log($"Instantiating {enemyObjects[i].name} into {enemyBattleStations[i]}");
                var enemyObject = Instantiate(enemyObjects[i], enemyBattleStations[i]);
                EnableShadow(enemyBattleStations[i]);
            }
        }
    }

    private void SetupHUD()
    {
        battleHUD = battleHUDObject.GetComponent<BattleHUD>();
        battleHUD.Initialise(partyUnits);
    }

    private void SetupTimers()
    {
        battleState = battleStateObject.GetComponent<BattleState>();
        //TODO get battle speed from config
        GlobalTimer.BattleSpeed = 0;

        //Calculate speed value from battle speed
        GlobalTimer.CalcGlobalSpeed();

        //Setup Party

        //TODO calc normal speed from parties
        //foreach actor in all actors on field
        GlobalTimer.CalcNormalSpeed(50);
    }

    private void EnableShadow(Transform battleStation)
    {
        var enemyContainerSpriteR = battleStation.GetComponent<SpriteRenderer>();
        enemyContainerSpriteR.enabled = true;
    }

    private void EndBattle()
    {
        //this is starting to become a general purpose battle management script...
        SceneManager.LoadScene("Menu");
    }
}