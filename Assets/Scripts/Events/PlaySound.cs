using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound
{
    [SerializeField] private GameObject associatedObj;

    private bool hasAudioSource;
    private bool hasObj;

    public AudioSource audioSource 
    {
        get;
        set;
    }
}
