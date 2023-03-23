using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action ExampleEvent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ExampleEvent?.Invoke();
        }
    }
}
