using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Actor/Status Effect", order = 5)]
public abstract class StatusEffect : ScriptableObject
{
    public abstract void OnApply(Actor u);
    public abstract void OnExpire(Actor u);
}
