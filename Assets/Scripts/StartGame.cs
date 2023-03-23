using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerClickHandler
{

    [SerializeField] GameObject activeButton;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("actOne");
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
