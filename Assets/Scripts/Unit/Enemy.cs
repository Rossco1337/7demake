using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Unit/Enemy", order = 15)]
public class Enemy : ScriptableObject
{
    /// <summary>Adds enemy specific traits like EXP gain to a <c>Unit</c></summary>
    //[Header("Enemy specific variables")]
    public string enemyName;
    public int maxHp;
    public int maxMp;
    //public int enemyId; it's in the stat table but with OOP i don't think it'll ever be called
    public int ap, gil, exp;
    public Item drop1;
    public float drop1percent;
}

public class Enemies
{
    public Enemy[] enemies;
}
