using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CharmDisplay : MonoBehaviour
{
    public Inventory inventory;

    void Start()
    {
        UpdateCharms();
    }

    void Update()
    {
        UpdateCharms();
    }

    public void UpdateCharms()
    {
        InvSlot[] charmSlots = GetComponentsInChildren<InvSlot>();
        for (int i = 0; i < charmSlots.Length; i++)
        {
            if (i < inventory.invCharms.Count)
            {
                charmSlots[i].AddCharm(inventory.invCharms[i]);
            }
            else
            {
                if (!charmSlots[i].occupied)
                {
                    charmSlots[i].ClearSlot();
                }
            }
        }
    }

    public void UpdateDisplay()
    {
        InvSlot[] slots = GetComponentsInChildren<InvSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.invPotions.Count)
            {
                slots[i].AddPotion(inventory.invPotions[i]);
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