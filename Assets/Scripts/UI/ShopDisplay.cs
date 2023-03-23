using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ShopDisplay : MonoBehaviour
{

    public ShopManager shopInventory;
    public Inventory playerInventory;

    int potionCount;
    int charmCount;
    int abilityCount;

    void Start()
    {
        // shopInventory = ShopManager.shopPotions;
        UpdateDisplay();
        potionCount = 0;
        charmCount = 0;
        abilityCount = 0;
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        ShopSlot[] shopSlots = GetComponentsInChildren<ShopSlot>();


        for (int i = 0; i < shopSlots.Length; i++)
        {
            ShopSlot slot = shopSlots[i];

            if (slot.tag == "potionSlot" && !slot.isOccupied)
            {
                slot.AddPotion(shopInventory.shopPotions[potionCount]);
                potionCount++;
                Debug.Log(potionCount);
                potionCount = potionCount >= 3 ? 0 : potionCount;
                slot.isOccupied = true;
            }
            else if (slot.tag == "charmSlot" && !slot.isOccupied)
            {
                slot.AddCharm(shopInventory.shopCharms[charmCount]);
                charmCount++;
                charmCount = charmCount >= 3 ? 0 : charmCount;
                slot.isOccupied = true;
            }
            else if (slot.tag == "abilitySlot" && !slot.isOccupied)
            {
               slot.AddAbility(shopInventory.shopAbilities[abilityCount]);
               abilityCount++;
               abilityCount = abilityCount >= 3 ? 0 : abilityCount;
               slot.isOccupied = true;
            }
            else
            {
                if (slot.purchased)
                {
                    slot.ClearSlot();
                }
            }
        }
    }

    public void RemoveShopPotion(Potion potion)
    {
        // playerInventory.AddPotion(potion);
        shopInventory.shopPotions.Remove(potion);
    }

    public void RemoveShopAbility(Ability ability)
    {
        // playerInventory.AddAbility(ability);
        shopInventory.shopAbilities.Remove(ability);
    }

    public void RemoveShopCharm(Charm charm)
    {
        // playerInventory.AddCharm(charm);
        shopInventory.shopCharms.Remove(charm);
    }
}
