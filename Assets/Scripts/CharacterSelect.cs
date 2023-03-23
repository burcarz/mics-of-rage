using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerClickHandler,
IDeselectHandler
{
    Vector3 cachedScale;

    [SerializeField] new Camera camera;
    Vector3 camTarget;
    public Image image;

    [SerializeField] GameEvent sEvent;

    public GameObject statSheet;
    public string charName;
    
    public bool selected;

    void Start()
    {
        cachedScale = transform.localScale;
        statSheet.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        if (Input.GetMouseButton(0))
        {
            selected = true;

            statSheet.SetActive(true);
            sEvent.Raise();
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Deselected");
        selected = false;
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        // image.transform.localScale = new Vector3(2.0f, 1.5f, 1.5f);
        image.color = new Color(162, 162, 162);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        // image.transform.localScale = cachedScale;
        image.color = new Color(255, 255, 255);
     }

     public void OnMouseDown()
     {
        if (Input.GetMouseButton(1))
        {
            selected = false;
        }
     }
}
