using System;
using UnityEngine;

[Serializable]
public class Actor : MonoBehaviour
{
    /// <summary>Defines an actor in battle</summary>
    [Header("Base stats for all instances of this prefab")]
    public EnemyStats enemyStats;

    public PlayerStats playerStats;

    //[Header("If checked, stats will be loaded from playerdata:")]
    [Header("Instance-specific stats")]
    //public string sprite; //remove soon?
    //public string actorName;
    //level stat is accessed for some abilities, but should never be instantiated, right?
    public bool backRow;

    public int currentHp, currentMp, strength, magicatk, defence, magicdef, dexterity, evasion, luck;

    [Header("Status")]
    //TODO: separation of shared/non-shared state
    //i don't *think* an enemy will be inst. with any status
    //but it will probably be persistant on players actors.
    //as always, prototype first, optimise later
    public Status[] status;


    private bool isPlayer;

    public void Awake()
    {
        CheckActorType();
        BuildActor();
    }

    public void Update()
    {
        if (currentHp < 1) Die();
    }

    public void CheckActorType()
    {
        //TODO find a better way of doing this, it's embarassing
        try
        {
            Debug.Log($"{enemyStats.ActorName}");
            isPlayer = false;
        }
        catch
        {
            isPlayer = true;
        }
    }

    public void BuildActor()
    {
        if (!isPlayer)
        {
            name = enemyStats.ActorName;
            currentHp = enemyStats.MaxHp;
            currentMp = enemyStats.MaxMp;
        }
        else
        {
            name = playerStats.ActorName;
            currentHp = PlayerSave.LoadInt(name, "currentHp");
        }
    }

    /* issue #3
    [Header("Type affinities")]
    public float fireAffin;
    public float iceAffin, lightningAffin, poisonAffin, GravityAffin, waterAffin, windAffin, holyAffin, restorAffin, cutAffin, hitAffin, punchAffin, shootAffin, shoutAffin, hiddenAffin;
    */

    //public string drop1, drop2, steal3, morph, manipulate1, manipulate2;
    //public int drop1rate, drop2rate, steal3rate;

    public void RemoveStatus(Status status)
    {
        throw new NotImplementedException();
    }

    public void Die()
    {
        //this should be a temporary effect which adds the KO status
        //and doesn't remove the actor from battle, but lets do it for testing
        Destroy(gameObject);
    }
}