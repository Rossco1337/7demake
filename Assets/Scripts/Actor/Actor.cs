using UnityEngine;
[System.Serializable]
public class Actor : MonoBehaviour {
    /// <summary>Defines an actor in battle</summary>
    [Header("Base stats for all instances of this prefab")]
    public EnemyStats enemyStats;
    public PlayerStats playerStats;
    [Header("If checked, stats will be loaded from playerdata:")]
    public bool persistentStats;
    
    [Header("Instance-specific stats")]
    //public string sprite; //remove soon?
    //public string actorName;
    //level stat is accessed for some abilities, but should never be instantiated, right?
    public bool backRow;
    public int currentHP, currentMP, strength, magicatk, defence, magicdef, dexterity, evasion, luck;
    


    public void Awake()
    {
        if (persistentStats)
        {
            int maxHP;
            //actorName = PlayerPrefs.GetString("p1Name", "NAME_UNSET");
            currentHP = PlayerPrefs.GetInt("p1CurHP", 130);
            maxHP = PlayerPrefs.GetInt("p1MaxHP", 130);

        }
        else
        {
            //actorName = baseStats.actorName;
            currentHP = enemyStats.MaxHp;
            currentMP = enemyStats.MaxMp;
        }
    }

    public void Update()
    {
        if (currentHP < 1)
        {
            Die();
        }
    }

    [Header("Status")]
    //TODO: separation of shared/non-shared state
    //i don't *think* an enemy will be inst. with any status
    //but it will probably be persistant on players actors.
    //as always, prototype first, optimise later
    public Status[] status;

    /* issue #3
    [Header("Type affinities")]
    public float fireAffin;
    public float iceAffin, lightningAffin, poisonAffin, GravityAffin, waterAffin, windAffin, holyAffin, restorAffin, cutAffin, hitAffin, punchAffin, shootAffin, shoutAffin, hiddenAffin;
    */ 

    //public string drop1, drop2, steal3, morph, manipulate1, manipulate2;
    //public int drop1rate, drop2rate, steal3rate;

    public void RemoveStatus(Status status)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        //this should be a temporary effect which adds the KO status
        //and doesn't remove the actor from battle, but lets do it for testing
        Destroy(gameObject);
    }
}
