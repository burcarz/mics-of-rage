using System;
using UnityEngine;

[Serializable]

public class CodeGameEventListener : IGameEventListener
{
    [SerializeField] private GameEvent @event;

    private Action onResponse;

    public void OnEventRaised()
    {
        onResponse?.Invoke();
    }

    public void OnEnable(Action response)
    {
        if(@event != null) @event.RegisterListener(this);
        onResponse = response;
    }

    public void OnDisable()
    {
        if(@event != null) @event.UnregisterListener(this);
        onResponse = null;
    }
}
