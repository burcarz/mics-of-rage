using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombat
{
    Vector3 Position { get; }

    void Punch();

    void Kick();

}
