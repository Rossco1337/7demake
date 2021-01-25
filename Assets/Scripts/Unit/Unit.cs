using UnityEngine;
[System.Serializable]
public class Unit : MonoBehaviour {
    /// <summary>Defines an actor in battle</summary>
    [Header("Base stats for all friendly/enemy units")]

    public string unitName;
    public string sprite; //remove soon?
    public int currentHP, maxHP, currentMP, maxMP, strength, magicatk, defence, magicdef, dexterity, evasion, luck;
    public bool backRow;

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
