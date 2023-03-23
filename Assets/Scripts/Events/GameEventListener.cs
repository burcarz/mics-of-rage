using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [Tooltip("Event Register")]
    [SerializeField]
    private GameEvent @event;

    [Tooltip("Res to Invoke")]
    [SerializeField]
    private UnityEvent response;

    public void OnEnable()
    {
        if (@event != null) @event.RegisterListener(this);
    }

    public void OnDisable()
    {
        @event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
