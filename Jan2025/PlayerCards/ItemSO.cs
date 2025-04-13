using UnityEngine;
public enum ItemType  {weapon, armour, aux}
public enum Rarity {common, uncommon, rare, legendary}

[CreateAssetMenu(fileName = "NewItemSO", menuName = "Game/Item", order = 1)]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public ItemType rarity;
    public string description;
    bool isEquipped;
}
