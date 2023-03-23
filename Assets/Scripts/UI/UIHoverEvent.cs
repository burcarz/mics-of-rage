using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIHoverEvent : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerClickHandler
{
    Vector3 cachedScale;
    float scaleX;
    float scaleY;
    float scaleZ;
    Image bg;

    Item item;
    [SerializeField] Image image;

    public ShopSlot shopSlot;
    public GameObject toolTip;

    void Start()
    {
        cachedScale = transform.localScale;
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
    }

    public void OnPointerClick(PointerEventData eventData) // 3
     {
        shopSlot.BuyItem();
     }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        if (shopSlot.potion || shopSlot.charm)
        {
            image.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else
        {
            Vector3 rotation = new Vector3(45f, 0f, -8f);
            image.transform.eulerAngles = rotation;
        }

        toolTip.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        if (shopSlot.potion || shopSlot.charm)
        {
            image.transform.localScale = cachedScale;
        }
        else
        {
            Vector3 rotation = new Vector3(45f, 0f, 8f);
            image.transform.eulerAngles = rotation;
        }

        toolTip.SetActive(false);
     }
}
