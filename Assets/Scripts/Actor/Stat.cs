using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Actor/Stat", order = 5)]
public class Stat : ScriptableObject
{
    public string statName;
    public int value;
}