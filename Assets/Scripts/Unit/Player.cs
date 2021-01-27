using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Unit/Player", order = 15)]
public class Player : ScriptableObject, IHaveBattleStats
/// <summary>Adds player specific traits like accuracy to a <c>Unit</c></summary>
{
    public int playerID = 0;
    [Header("Base stats interface")]
    //[SerializeField] private string unitName;
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
    public string UnitName
    {
        get
        {
            return PlayerSave.LoadString(name, nameof(UnitName));
        }
        set
        {
            PlayerSave.SaveString(name, nameof(UnitName), value);
        }
    }
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

    [Header("Player stats")]
    //public int enemyId; it's in the stat table but with OOP i don't think it'll ever be called
    [SerializeField] private int strength;
    [SerializeField] private int vitality;
    [SerializeField] private int magic;
    [SerializeField] private int spirit;
    //i know these say "percent but that's what the data says
    [SerializeField] private int attackPercent;
    [SerializeField] private int magicDefPercent;
    public int Strength { get => strength; }
    public int Vitalty { get => vitality; }
    public int Magic { get => magic; }
    public int Spirit { get => spirit; }
    public int AttackPercent { get => attackPercent; }
    public int MagicDefPercent { get => magicDefPercent;  }
}