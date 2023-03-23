using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDisplay : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        Debug.Log(inventory.invAbilities.Count + " Potions in inventory");
        UpdateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        InvSlot[] slots = GetComponentsInChildren<InvSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.invAbilities.Count)
            {
                slots[i].AddAbility(inventory.invAbilities[i]);
            }
            else
            {
                if (!slots[i].occupied)
                {
                    slots[i].ClearSlot();
                }
            }
        }
    }
}
