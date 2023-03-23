using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance;

    private Potion[] potions;
    private Ability[] abilities;
    private Charm[] charms;
    private Item[] items;

    public Dictionary<int, Item> itemPool = new Dictionary<int, Item>();
    // public Dictionary<Ability, int> abilityPool = new Dictionary<Ability, int>();
    // public Dictionary<Charm, int> charmPool = new Dictionary<Charm, int>();

    void Awake()
    {
        PoolItems();
        
        if (!Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ITEM POOLING

    void PoolItems()
    {
        items = Resources.LoadAll<Item>("Items");
        foreach (var i in items)
        {
            try
            {
                i.inActive = false;
                i.ID = i.GenerateID();
                itemPool.Add(i.ID, i);
                Debug.Log(i.ID + " " + i);
            }
            catch (ArgumentException)
            {
                Debug.LogWarning("An element with this ID already Exists");
                throw;
            }
        }
    }

    void OnEnable()
    {

    }
}
