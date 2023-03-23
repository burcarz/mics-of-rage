using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerClickHandler
{

    [SerializeField] GameObject activeButton;
    [SerializeField] GameObject characterSelectScreen;
    [SerializeField] GameObject buttonContainer;

    [SerializeField] new Camera camera;

    Vector3 camTarget;

    void Start()
    {
        camTarget = new Vector3(0.83f, 0, -983);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        camera.transform.position = camTarget;

        buttonContainer.SetActive(true);
        characterSelectScreen.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        activeButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        activeButton.SetActive(false);
    }
}
