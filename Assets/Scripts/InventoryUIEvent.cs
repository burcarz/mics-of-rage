using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryUIEvent : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerClickHandler
{
    Vector3 cachedScale;
    Vector3 cachedPos;

    [SerializeField] Image image;
    [SerializeField] Image book;

    public InvSlot invSlot;
    public GameObject toolTip;
    public GameObject bookOpen;

    public AbilityManager abilityManager;
    public PotionManager potionManager;

    public AudioSource hoverSound;
    public AudioSource clickSound;

    private bool bookActive;

    void Start()
    {
        cachedScale = transform.localScale;
        cachedPos = transform.position;
    }

    // void Update()
    // {
    //     if (Input.GetButtonDown("cycle"))
    //     {
    //         CycleItem();
    //     }
    // }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        if (invSlot && invSlot.potion && invSlot.occupied)
        {
            Debug.Log("UI EVENT CALLED");
            GameStateManager.Instance.potion = invSlot.potion;
            invSlot.occupied = false;
            invSlot.UsePotion();
        }
        if (invSlot && invSlot.ability && invSlot.occupied)
        {
            abilityManager.ability = invSlot.ability;
        }
        if (book && !bookActive)
        {
            bookActive = true;
            bookOpen.SetActive(true);
        }
        else if (book && bookActive)
        {
            bookActive = false;
            bookOpen.SetActive(false);
        }
        clickSound.Play();
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        if (invSlot && invSlot.occupied)
        {
            image.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            invSlot.checkSelected();
            GameStateManager.Instance.potion = invSlot.potion;
            potionManager.isIdle = false;
            toolTip.SetActive(true);
        }

        if (book)
        {
            book.transform.localScale = new Vector3(5f, 5f, 5f);
            Vector3 rotation = new Vector3(45f, 0f, 50f);
            book.transform.eulerAngles = rotation;
        }

        hoverSound.Play();
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        if (invSlot && !invSlot.occupied)
        {
            // invSlot.isIdle = true;
            image.transform.localScale = cachedScale;
            toolTip.SetActive(false);
        }
        else if (toolTip && toolTip.activeSelf)
        {
            image.transform.localScale = cachedScale;
            toolTip.SetActive(false);
        }

        if (book)
        {
            book.transform.localScale = cachedScale;
            Vector3 rotation = new Vector3(45f, 0f, 0f);
            book.transform.eulerAngles = rotation;
        }

     }

    // public void CycleItem()
    //  {
    //     if (invSlot && invSlot.occupied)
    //     {
    //         image.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    //         invSlot.checkSelected();
    //         potionManager.potion = invSlot.potion;
    //         potionManager.isIdle = false;
    //         toolTip.SetActive(true);
    //     }
    //  }
}
