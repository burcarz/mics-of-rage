using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Ability,
    Potion,
    Charm
}

public enum Attributes
{
    Health,
    Shields,
    Energy,
    Defense,
    Speed,
    Damage
}

public abstract class Item : ScriptableObject
{
    public int ID;
    public GameObject prefab;
    public string displayName;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public Sprite icon;
    public int rarity;
    public int cost;
    public string flavor;
    public bool inActive = false;

    public ItemObject CreateItem()
    {
        ItemObject newItem = new ItemObject(this);
        return newItem;
    }

    public int GenerateID()
    {
        if (ID == 0)
        {
            ID = UnityEngine.Random.Range(10000, 99999);
        }

        return ID;
    }
}

[System.Serializable]
public class ItemObject
{
    public string displayName;
    public int ID;
    public ItemObject(Item item)
    {
        displayName = item.name;
        if (item.ID == 0)
        {
            item.ID = UnityEngine.Random.Range(10000, 99999);
        }
        ID = item.ID;
    }
}
