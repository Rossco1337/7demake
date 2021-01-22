using UnityEngine;
[System.Serializable]
public class Unit : MonoBehaviour {
    /// <summary>Defines an actor in battle</summary>
    [Header("Base stats for all friendly/enemy units")]

    public string unitName, sprite;
    public int currentHP, maxHP;
    //public string unitName, sprite, drop1, drop2, steal3, morph, manipulate1, manipulate2;
    //public int id, currentHP, maxHP, hp, mp, strength, magicatk, defence, magicdef, dexterity, evasion, luck, drop1rate, drop2rate, steal3rate;
}
