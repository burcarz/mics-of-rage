using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /* 
    the player inventory, the inventory contains
    potions,
    charms and 
    player controlled abilities
    */

    // lists of current items inside the player inventory
    public List<Potion> invPotions = new List<Potion>();
    public List<Charm> invCharms = new List<Charm>();
    public List<Ability> invAbilities = new List<Ability>();

    public int potionSlots = 2;
    public int charmSlots = 8008135;
    public int abilitySlots = 3;

    public bool potionActive;

    void Awake()
    {
        if (GameStateManager.Instance)
        {
            invPotions = GameStateManager.Instance.invPotions;
            invCharms = GameStateManager.Instance.invCharms;
            invAbilities = GameStateManager.Instance.invAbilities;
        }
    }

    public void addPotion(Potion newPotion)
    {
        if (invPotions.Count < potionSlots)
        {
            Debug.Log("Potion Added");
            invPotions.Add(newPotion);
            // GameStateManager.Instance.invPotions.Add(newPotion);
        }
        else
        {
            Debug.Log("your consumable slots are full");
        }
    }

    public void addCharm(Charm newCharm)
    {
        Debug.Log("Charm added");
        invCharms.Add(newCharm);
        // GameStateManager.Instance.invCharms.Add(newCharm);
    }

    public void addAbility(Ability newAbility)
    {
        if (invAbilities.Count < abilitySlots)
        {
            Debug.Log("Ability added");
            invAbilities.Add(newAbility);
            // GameStateManager.Instance.invAbilities.Add(newAbility);
        }
        else
        {
            Debug.Log("Your joke slots are full");
        }

    }

    public void RemovePotion(Potion potion)
    {
        invPotions.Remove(potion);
        // GameStateManager.Instance.invPotions.Remove(potion);
        Debug.Log(potion + " " + invPotions.Count);
    }

    public void RemoveAbility(Ability ability)
    {
        invAbilities.Remove(ability);
        // GameStateManager.Instance.invAbilities.Remove(ability);
    }

    public void UsePotion(Potion potion)
    {
        potionActive = true;
        Debug.Log("INVENTORY CALLED" + " " + potionActive);
        invPotions.Remove(potion);
        potionActive = false;
    }
}
