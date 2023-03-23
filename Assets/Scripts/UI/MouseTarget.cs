using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
            // mousePosition = Input.mousePosition;
            // mousePosition.z = 0;
            // transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
