using UnityEngine;
[System.Serializable]
public class Unit : MonoBehaviour {
    /// <summary>Defines an actor in battle</summary>
    [Header("Base stats for all instances of this prefab")]
    public Enemy baseStats;
    [Header("If checked, stats will be loaded from playerdata:")]
    public bool persistentStats;
    
    [Header("Instance-specific stats")]
    //public string sprite; //remove soon?
    public string unitName;
    public int currentHP, currentMP, strength, magicatk, defence, magicdef, dexterity, evasion, luck;
    public bool backRow;


    public void Awake()
    {
        if (persistentStats)
        {
            int maxHP;
            unitName = PlayerPrefs.GetString("p1Name", "NAME_UNSET");
            currentHP = PlayerPrefs.GetInt("p1CurHP", 130);
            maxHP = PlayerPrefs.GetInt("p1MaxHP", 130);

        }
        else
        {
            unitName = baseStats.enemyName;
            currentHP = baseStats.maxHp;
            currentMP = baseStats.maxMp;
        }
    }

    [Header("Status")]
    //TODO: separation of shared/non-shared state
    //i don't *think* an enemy will be inst. with any status
    //but it will probably be persistant on players units.
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
}
