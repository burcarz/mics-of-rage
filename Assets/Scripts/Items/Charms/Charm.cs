using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charm", menuName = "Charm")]
public class Charm : Item
{
    public float value;
    public float activeTime;

    public void Awake()
    {
        type = ItemType.Charm;
    }

    void Update()
    {
    }

    public virtual void Activate(GameObject parent)
    {
        
    }

    public virtual void Deactivate(GameObject parent)
    {

    }
}
