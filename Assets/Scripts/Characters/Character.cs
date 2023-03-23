using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IHurtable, ICombat
{

    public float maxHealth;
    public float currentHealth;

    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }
    
    public int Health { get; set; }

    public void Damage(float damage)
    {
        
    }

    public void Punch()
    {

    }

    public void Kick()
    {

    }

}
