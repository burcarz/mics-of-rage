using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharmSlot : MonoBehaviour
{
    Item charm;

    public Image icon;

    public Player player;
    public InventoryDisplay display;

    public void AddCharm(Item newCharm)
    {
        charm = newCharm;

        if (!charm.icon)
        {
            icon.sprite = charm.icon;
            icon.enabled = true;
        }
    }

    public void UseCharm()
    {
        // if the charm has limited uses then augment the charm display to reflect that
    }
}
