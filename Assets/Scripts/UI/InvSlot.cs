using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvSlot : MonoBehaviour
{
    public Potion potion;
    public Charm charm;
    public Ability ability;

    public Image icon;

    public TMP_Text displayName;
    public TMP_Text description;
    public TMP_Text flavor;

    public Player player;
    public InventoryDisplay display;

    public GameObject shadow;

    public bool occupied;
    public bool selected = false;

    public void Start()
    {
        occupied = false;
    }

    public void checkSelected()
    {
        display.UpdateSelected(shadow);
    }

    public void AddPotion(Potion newPotion)
    {
        potion = newPotion;

        if (potion)
        {
            icon.sprite = potion.icon;
            icon.enabled = true;
            flavor.text = potion.flavor;
            description.text = potion.description;
            displayName.text = potion.displayName;
        }

        occupied = true;
    }

    public void AddCharm(Charm newCharm)
    {
        charm = newCharm;

        if (charm)
        {
            icon.sprite = charm.icon;
        }
    }

    public void AddAbility(Ability newAbility)
    {
        ability = newAbility;

        if (ability)
        {
            icon.sprite = ability.icon;
        }

        occupied = true;
    }

    public void ClearSlot()
    {
        if (potion)
        {
            potion = null;
        }
        
        icon.enabled = false;
        occupied = false;
    }

    public void UsePotion()
    {
        Debug.Log("SLOT CALLED");
        display.RemovePotion(potion);
        ClearSlot();
    }
}
