using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Actor/Player", order = 15)]
public class PlayerStats : ScriptableObject, IHaveBattleStats
    /// <summary>Adds player specific traits like accuracy to a <c>Actor</c></summary>
{
    [Header("Base stats interface")] [SerializeField]
    private string actorName;

    [SerializeField] private int level;
    [SerializeField] private int maxHp;
    [SerializeField] private int maxMp;
    [SerializeField] private int dexterity;
    [SerializeField] private int luck;


    [Header("Player stats")]
    //public int enemyId; it's in the stat table but with OOP i don't think it'll ever be called
    [SerializeField]
    private int strength;

    [SerializeField] private int vitality;
    [SerializeField] private int magic;
    [SerializeField] private int spirit;
    public int Strength => strength;
    public int Vitalty => vitality;
    public int Magic => magic;

    public int Spirit => spirit;

    //Derived player equipment stats below, do not add set{}:
    public int AttackPercent => throw new NotImplementedException();
    public int MagicDefPercent => throw new NotImplementedException();

    public string ActorName
    {
        get => actorName;
        set => PlayerSave.SaveString(name, nameof(ActorName), value);
    }

    public int Level => level;
    public int MaxHp => maxHp;
    public int MaxMp => maxMp;
    public int Luck => luck;

    public int Dexterity => dexterity;

    //Derived player stats below, do not add set{}:
    public int Attack => strength; //TODO Plus WeaponATK!
    public int Defence => vitality; //TODO plus ArmourDEF!
    public int DefencePercent => dexterity / 4; //TODO plus ArmourDEF
    public int MagicAttack => magic; //TODO verify this is all
    public int MagicDefence => spirit; //TODO verify this is all
}