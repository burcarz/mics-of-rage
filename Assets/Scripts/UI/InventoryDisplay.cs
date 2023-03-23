using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    GameObject[] shadows;

    private int cycleNum = 0;

    InvSlot[] invSlots;

    void Start()
    {
        invSlots = GetComponentsInChildren<InvSlot>();
        Debug.Log(inventory.invPotions.Count + " Potions in inventory" +
        inventory.invCharms.Count + " Charms in inventory");
        UpdateDisplay();
    }

    void Update()
    {
        UpdateDisplay();

        if (Input.GetButtonDown("cycle"))
        {
            CycleSelected();
        }
    }

    public void RemovePotion(Potion potion)
    {
        Debug.Log("DISPLAY SCRIPT EVENT CALLED");
        inventory.UsePotion(potion);
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
        }
    }

    public void UpdateDisplay()
    {
        InvSlot[] slots = GetComponentsInChildren<InvSlot>();
        if (inventory.invPotions.Count == 0)
        {
            return;
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (i <= inventory.invPotions.Count && !slots[i].occupied)
            {
                // Debug.Log("ADDEDEDED");
                slots[i].AddPotion(inventory.invPotions[i]);
                // WipeDisplay(i);
                // if (!inventory.invPotions[i])
                // {
                //     Debug.Log(false);
                // }
            }
            else if (!slots[i].occupied)
            {
                slots[i].ClearSlot();
            }

        }
    }

    public void WipeDisplay(int d)
    {
        for (int i = 0; i < inventory.invPotions.Count; i++)
        {
            if (inventory.invPotions[i] == null)
            {
                invSlots[d].ClearSlot();
            }
        }
    }

    public void UpdateSelected(GameObject parent)
    {
        Image image;
        shadows = GameObject.FindGameObjectsWithTag("shadow");
        Debug.Log(shadows.Length);
        foreach (GameObject shadow in shadows)
        {
            image = shadow.GetComponent<Image>();
            image.enabled = false;
        }
        image = parent.GetComponent<Image>();
        image.enabled = true;
    }

    public void CycleSelected()
    {
        Image image;
        shadows = GameObject.FindGameObjectsWithTag("shadow");

        InvSlot[] slot = GetComponentsInChildren<InvSlot>();

        foreach (GameObject shadow in shadows)
        {
            image = shadow.GetComponent<Image>();
            image.enabled = false;
        }
        
        if (cycleNum >= inventory.invPotions.Count)
        {
            cycleNum = 0;
        }

        for (int i = 0;  i < shadows.Length; i++)
        {
            image = shadows[i].GetComponent<Image>();
            if (i == cycleNum && slot[cycleNum].potion)
            {
                image.enabled = true;
                Debug.Log(slot[cycleNum].potion);
                slot[cycleNum].potion.selected = true;
                GameStateManager.Instance.potion = slot[cycleNum].potion;
                
            }
            else 
            {
                slot[i].potion.selected = false;
                image.enabled = false;
            }
        }

        cycleNum++;
        Debug.Log(cycleNum);
        
        
    }
}
