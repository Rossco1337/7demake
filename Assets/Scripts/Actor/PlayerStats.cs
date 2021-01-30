using UnityEngine;
using System;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Actor/Player", order = 15)]
public class PlayerStats : ScriptableObject, IHaveBattleStats
/// <summary>Adds player specific traits like accuracy to a <c>Actor</c></summary>
{
    [Header("Base stats interface")]
    [SerializeField] private string actorName;
    [SerializeField] private int level;
    [SerializeField] private int maxHp;
    [SerializeField] private int maxMp;
    [SerializeField] private int dexterity;
    [SerializeField] private int luck;
    public string ActorName
    {
        get => actorName;
        set => PlayerSave.SaveString(name, nameof(ActorName), value);
    }
    public int Level { get => level; }
    public int MaxHp { get => maxHp; }
    public int MaxMp { get => maxMp; }
    public int Luck { get => luck; }
    public int Dexterity { get => dexterity; }
    //Derived player stats below, do not add set{}:
    public int Attack => strength; //TODO Plus WeaponATK!
    public int Defence => vitality; //TODO plus ArmourDEF!
    public int DefencePercent => (dexterity / 4); //TODO plus ArmourDEF
    public int MagicAttack => magic; //TODO verify this is all
    public int MagicDefence => spirit; //TODO verify this is all
    
    

    [Header("Player stats")]
    //public int enemyId; it's in the stat table but with OOP i don't think it'll ever be called
    [SerializeField] private int strength;
    [SerializeField] private int vitality;
    [SerializeField] private int magic;
    [SerializeField] private int spirit;
    public int Strength { get => strength; }
    public int Vitalty { get => vitality; }
    public int Magic { get => magic; }
    public int Spirit { get => spirit; }
    //Derived player equipment stats below, do not add set{}:
    public int AttackPercent { get => throw new NotImplementedException(); }
    public int MagicDefPercent { get => throw new NotImplementedException();  }
}