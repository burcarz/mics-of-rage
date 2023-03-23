using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum ItemComp
{
    Ability,
    Potion,
    Charm,
}

public class ShopManager: MonoBehaviour
{
    public Ability[] abilities;
    public Potion[] potions;
    public Charm[] charms;

    // ItemComp typeComp;

    Item itemType;

    public Inventory inventory;

    public ItemManager pools;

    public List<Potion> shopPotions = new List<Potion>();
    public List<Charm> shopCharms = new List<Charm>();
    public List<Ability> shopAbilities = new List<Ability>();

    

    private int potionSlots = 3;
    private int charmSlots = 3;
    private int abilitySlots = 3;

    public string itemComp;

    void Awake()
    {
        // GenerateShopItems();
    }

    void Start()
    {
        GenerateShopItems();
    }

    void CreateShopPotion(Item item)
    {

    }

    void GenerateShopItems()
    {
        // convert items in Dictionary to child types and add them to seperate shop Lists
        // generate a cost value for each shop item
        // remove the item from the dictionary
        foreach (var i in pools.itemPool)
        {
            // if (!i.Value.inActive) continue;

            if (shopPotions.Count < potionSlots &&
            i.Value.type.ToString() == ItemComp.Potion.ToString()
            )
            {
                Potion potion = i.Value as Potion;
                Debug.Log(potion);
                potion.cost = GenerateCost(potion.rarity);
                shopPotions.Add(potion);
                i.Value.inActive = true;
            }

            if (shopCharms.Count < charmSlots &&
            i.Value.type.ToString() == ItemComp.Charm.ToString()
            )
            {
                Charm charm = i.Value as Charm;
                charm.cost = GenerateCost(charm.rarity);
                shopCharms.Add(charm);
                i.Value.inActive = true;
            }

            if (shopAbilities.Count < abilitySlots &&
            i.Value.type.ToString() == ItemComp.Ability.ToString()
            )
            {
                Ability ability = i.Value as Ability;
                ability.cost = GenerateCost(ability.rarity);
                shopAbilities.Add(ability);
                i.Value.inActive = true;
            }
        }
    }

    int GenerateCost(int rarity)
    {
        int cost;
        Random rnd = new Random();
        if (rarity == 0)
        {
            cost = rnd.Next(80, 110);
        }
        else if (rarity == 1)
        {
            cost = rnd.Next(130, 150);
        }
        else if (rarity == 2)
        {
            cost = rnd.Next(170, 200);
        }
        else
        {
            cost = rnd.Next(220, 300);
        }
        return cost;
    }

    public void RemovePotion(Potion potion)
    {
        itemComp = potion.type.ToString();

        Debug.Log(potion.type);
        inventory.addPotion(potion);
        shopPotions.Remove(potion);
        Debug.Log("ITEM REMOVED");
    }
}
