internal class ItemEffectRemoveStatus : ItemEffect
{
    public Status statusToRemove;

    public override void OnConsume(Actor u)
    {
        u.RemoveStatus(statusToRemove);
    }
}