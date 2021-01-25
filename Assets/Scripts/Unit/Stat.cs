using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Unit/Stat", order = 5)]
public class Stat : ScriptableObject
{
    public string statName;
    public int value;
}
