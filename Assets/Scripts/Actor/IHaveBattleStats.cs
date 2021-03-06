﻿public interface IHaveBattleStats
    /// <summary>Defines base stats of player or enemy <c>Actor</c></summary>
{
    string ActorName { get; }
    int Level { get; }
    int MaxHp { get; }
    int MaxMp { get; }
    int Attack { get; }
    int Defence { get; }
    int DefencePercent { get; }
    int MagicAttack { get; }
    int MagicDefence { get; }
    int Dexterity { get; }
    int Luck { get; }
}