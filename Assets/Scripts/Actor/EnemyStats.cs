using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Actor/Enemy", order = 15)]
public class EnemyStats : ScriptableObject, IHaveBattleStats
    /// <summary>Hardcoded enemy stats for an <c>Actor</c></summary>
{
    [Header("Base stats interface")] [SerializeField]
    private string actorName;

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

    [Header("Enemy stats")]
    //public int enemyId; it's in the stat table but with OOP i don't think it'll ever be called
    [SerializeField]
    private int ap;

    [SerializeField] private int gil;
    [SerializeField] private int exp;
    [SerializeField] private Item drop1;
    [SerializeField] private float drop1percent;
    public int Ap => ap;
    public int Gil => gil;
    public int Exp => exp;
    public Item Drop1 => drop1;
    public float Drop1percent => drop1percent;
    public string ActorName => actorName;
    public int Level => level;
    public int MaxHp => maxHp;
    public int MaxMp => maxMp;
    public int Attack => attack;
    public int Defence => defence;
    public int DefencePercent => defencePercent;
    public int MagicAttack => magicAttack;
    public int MagicDefence => magicDefence;
    public int Dexterity => dexterity;
    public int Luck => luck;
}

public class Enemies
{
    public EnemyStats[] enemies;
}