using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionHandler : MonoBehaviour
{
    [SerializeField] private CodeGameEventListener beginEventListener;
    [SerializeField] CharacterSelect[] charPanels;

    public int index = 0;

    void Start()
    {
        foreach (var panel in charPanels)
        {
            Debug.Log(panel.selected + " " + panel.name);
        }
    }

    void Update()
    {
        foreach (var panel in charPanels)
        {
            if (panel.selected)
            {
                panel.image.color = new Color(255, 249, 0);
            }
            if (!panel.selected)
            {
                panel.image.color = new Color(255, 255, 255);
            }
            if (Input.GetMouseButton(1))
            {
                panel.selected = false;
                panel.statSheet.SetActive(false);
            }
        }
    }

    public void OnEnable()
    {
        beginEventListener?.OnEnable(OnBeginEventRaised);
    }

    public void OnBeginEventRaised()
    {

    }
}
