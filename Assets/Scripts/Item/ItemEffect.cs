using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/Item Effect", order = 1)]
public abstract class ItemEffect : ScriptableObject
{
    //public ActorStat stat;
    public int statChange;

    public Status status;

    public abstract void OnConsume(Actor u);
}
