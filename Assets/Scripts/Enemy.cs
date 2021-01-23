using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    /// <summary>Adds enemy specific traits like EXP gain to a <c>Unit</c></summary>
    [Header("Enemy specific variables")]
    public int enemyId;
    public int ap, gil, exp;
    public Item drop1;
    // Start is called before the first frame update

    private void Awake()
    {
        {
            //enemy hp should always be full when an enemy is created
            //player hp will change between encounters
            currentHP = maxHP;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Enemies
{
    public Enemy[] enemies;
}
