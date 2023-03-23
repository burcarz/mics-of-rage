using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStageTrigger : MonoBehaviour
{
    private bool hasBeenTriggered;
    
    [SerializeField] private GameEvent nEvent;
    private bool hasGameEvent = true;
   
    void Start()
    {
        hasGameEvent = nEvent != null;

        if (!hasGameEvent)
        {
            Debug.LogWarning("NO GAME EVENT ASSIGNED");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("stage") && !hasBeenTriggered)
        {
            // hasBeenTriggered = true;
            nEvent.Raise();
        }
    }

    public void EndStage()
    {
        if (!hasBeenTriggered) nEvent.Raise();
    }
}
