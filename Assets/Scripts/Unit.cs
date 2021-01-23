using UnityEngine;
[System.Serializable]
public class Unit : MonoBehaviour {
    /// <summary>Defines an actor in battle</summary>
    [Header("Base stats for all friendly/enemy units")]

    public string unitName;
    public string sprite; //remove soon?
    public int currentHP, maxHP, currentMP, maxMP, strength, magicatk, defence, magicdef, dexterity, evasion, luck;
    public bool backRow;

    /* issue #3
    [Header("Type affinities")]
    public float fireAffin;
    public float iceAffin, lightningAffin, poisonAffin, GravityAffin, waterAffin, windAffin, holyAffin, restorAffin, cutAffin, hitAffin, punchAffin, shootAffin, shoutAffin, hiddenAffin;
    */ 

    //public string drop1, drop2, steal3, morph, manipulate1, manipulate2;
    //public int drop1rate, drop2rate, steal3rate;
}
