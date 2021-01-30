using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ItemEffectRemoveStatus : ItemEffect
{
    public Status statusToRemove;

    public override void OnConsume(Actor u)
    {
        u.RemoveStatus(statusToRemove);
    }
}
