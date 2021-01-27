using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Unit/Enemy", order = 15)]
public class Enemy : ScriptableObject, IHaveBattleStats
/// <summary>Adds enemy specific traits like EXP gain to a <c>Unit</c></summary>
{
    [Header("Base stats interface")]
    [SerializeField] private string unitName;
    [SerializeField] private int level;
    [SerializeField] private int maxHp;
    [SerializeField] private int maxMp;
    [SerializeField] private int attack;
    [SerializeField] private int defence;
    [SerializeField] private int defencePercent;
    [SerializeField] private int magicAttack;
    [SerializeField] private int magicDefence;
    [SerializeField] private int dexterity;
    [SerializeField] private int luck;
    public string UnitName { get => unitName; }
    public int Level { get => level; }
    public int MaxHp { get => maxHp; }
    public int MaxMp { get => maxMp; }
    public int Attack { get => attack; }
    public int Defence { get => defence; }
    public int DefencePercent { get => defencePercent; }
    public int MagicAttack { get => magicAttack; }
    public int MagicDefence { get => magicDefence; }
    public int Dexterity { get => dexterity; }
    public int Luck { get => luck; }

    [Header("Enemy stats")]
    //public int enemyId; it's in the stat table but with OOP i don't think it'll ever be called
    [SerializeField] private int ap;
    [SerializeField] private int gil;
    [SerializeField] private int exp;
    [SerializeField] private Item drop1;
    [SerializeField] private float drop1percent;
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
