using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Player;
    public float dampTime = 0.4f;
    private Vector3 cameraTarget;
    private Vector3 velocity = Vector3.zero;

    [Range(0,2)]
    [SerializeField] float rightLimit;
    [Range(0,2)]
    [SerializeField] float leftLimit;
    [Range(0,2)]
    [SerializeField] float offset;


    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        cameraTarget = new Vector3(Player.position.x, cameraPosition.position.y, cameraPosition.position.z);
        if (Player.position.x >= cameraPosition.position.x + rightLimit)
        {
            cameraPosition.position = Vector3.SmoothDamp(cameraPosition.position, cameraTarget, ref velocity, dampTime);
        }
        else if (Player.position.x <= cameraPosition.position.x - leftLimit)
        {
            cameraPosition.position = Vector3.SmoothDamp(cameraPosition.position, cameraTarget, ref velocity, dampTime);
        }
    }
}
