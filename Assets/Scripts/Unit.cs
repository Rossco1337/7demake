using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Unit : MonoBehaviour {
    public string unitName;
    public int id, currentHP, maxHP;
    public string sprite;

}
[System.Serializable]
public class Enemies
{
    public Unit[] enemies;
}