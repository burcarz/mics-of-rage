using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class EndStageBanner : MonoBehaviour
{
    [SerializeField] private CodeGameEventListener beginEventListener;

    [SerializeField] private GameObject endStageBanner;
    [SerializeField] private PlayerInput player;
    [SerializeField] private LouWeapon weapon;

    private bool hasFinishedMoving = false;

    private void OnEnable()
    {
        beginEventListener?.OnEnable(OnBeginEventRaised);
    }

    void Start()
    {

    }


    private void OnBeginEventRaised()
    {
        if (hasFinishedMoving) return;

        Debug.Assert(endStageBanner != null, nameof(endStageBanner) + " != null");
        endStageBanner.SetActive(true);
    }
}
