using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Unit/Enemy", order = 15)]
public class Enemy : ScriptableObject
{
    /// <summary>Adds enemy specific traits like EXP gain to a <c>Unit</c></summary>
    //[Header("Enemy specific variables")]
    private string enemyName;
    private int maxHp;
    private int maxMp;
    //public int enemyId; it's in the stat table but with OOP i don't think it'll ever be called
    private int exp;
    private Item drop1;
    private float drop1percent;
    private int ap;
    private int gil;

    public int MaxHp { get => maxHp; }
    public string EnemyName { get => enemyName; }
    public int MaxMp { get => maxMp; }
    public int Ap { get => ap; }
    public int Gil { get => gil; }
    public int Exp { get => exp; }
    public Item Drop1 { get => drop1; }
    public float Drop1percent { get => drop1percent; }
}

public class Enemies
{
    public Enemy[] enemies;
}
