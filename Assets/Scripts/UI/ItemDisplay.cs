using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    private Image icon;

    private void Awake()
    {
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
    }
}
