using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInteract : MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler,
IPointerClickHandler
{
    Vector3 cachedScale;
    Image bg;
    Item item;
    [SerializeField] GameObject button;
    [SerializeField] GameObject buttonSel;
    [SerializeField] GameObject buttonContainer;

    [SerializeField] new Camera camera;
    Vector3 camTarget;
    [SerializeField] Image image;
    [SerializeField] GameObject charSelect;

    void Start()
    {
        cachedScale = transform.localScale;
        charSelect.SetActive(false);
        buttonSel.SetActive(true);
        button.SetActive(false);

        camTarget = new Vector3(0.83f, 0, -983);
        camera.transform.position = camTarget;

    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        // SceneManager.LoadScene("actOne");
        camTarget = new Vector3(camera.transform.position.x + 10, camera.transform.position.y,
         camera.transform.position.z);

         camera.transform.position = camTarget;
         charSelect.SetActive(true);
         buttonContainer.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        // transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        button.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        // transform.localScale = cachedScale;
        button.SetActive(false);
     }
}
