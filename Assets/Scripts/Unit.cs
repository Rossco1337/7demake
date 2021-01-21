using UnityEngine;
[System.Serializable]
public class Unit : MonoBehaviour {
    public string unitName, sprite;
    public int id, currentHP, maxHP;
}
[System.Serializable]
public class Enemies
{
    public Unit[] enemies;
}