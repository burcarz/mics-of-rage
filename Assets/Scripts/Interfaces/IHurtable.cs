using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtable
{
    int Health { get; set; }

    void Damage(float damage);
}

