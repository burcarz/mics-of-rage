using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class Ability : Item
{
    // HOW LONG BEFORE YOU CAN USE THE ABILITY AGAIN
    public float cooldownTime;
    // HOW LONG THE ABILITY IS ACTIVE FOR
    public float activeTime;
    // HOW MUCH THE ABILITY COSTS TO USE
    public float energyCost;
    // THE ABILITIES RARITY, WILL BE USED TO CALCULATE SHOP PRICES AND DROP CHANCES
    // 0 = COMMON, 1 = UNCOMMON, 2 = RARE, 3 = ULTRARARE
    // USED FOR COST CALCULATION AS WELL

    public void Awake()
    {
        type = ItemType.Ability;
    }

    public virtual void Activate(GameObject parent)
    {

    }

    public virtual void Active(GameObject parent)
    {
        
    }

    public virtual void BeginCooldown(GameObject parent)
    {
        
    }
}
