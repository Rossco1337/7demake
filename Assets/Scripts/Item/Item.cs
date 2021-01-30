using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/Item", order = 1)]
public class Item : ScriptableObject
{
    public Sprite icon;
    public ItemSlot slot;
    public ItemEffect[] effects;
    public void OnConsume(Actor u)
    {
        for(int i=0; i < effects.Length; i++)
        {
            effects[i].OnConsume(u);
        }
    }
}
