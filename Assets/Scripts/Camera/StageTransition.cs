using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageTransition : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerClickHandler
{
    Vector3 cachedScale;
    Image bg;
    Item item;

    [SerializeField] private GameEvent nEvent;
    
    public GameObject endStageBanner;
    public Vector3 target;
    public new Transform camera;
 
    void Start()
    {
        target = new Vector3(8, 1.9f, -1.1f);
        cachedScale = transform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        nEvent.Raise();
        Debug.Log(eventData + " clicked");
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        transform.localScale = cachedScale;
     }
}