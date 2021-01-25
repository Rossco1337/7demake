using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Unit/Status Effect", order = 5)]
public abstract class StatusEffect : ScriptableObject
{
    public abstract void OnApply(Unit u);
    public abstract void OnExpire(Unit u);
}
