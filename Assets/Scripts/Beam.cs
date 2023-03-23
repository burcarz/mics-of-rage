using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private SpriteRenderer render;

    public AudioSource audioBeam;

    public float speed = 3f;

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        // start.position = transform.position;
        audioBeam.Play();
        audioBeam.loop = true;
    }

    void Update()
    {
        // audioBeam.Play();
    }

    public void GenerateBeam(Transform target)
    {
        end = target;

        if (start != null && end != null)
        {
            transform.position = start.position;
            // transform.LookAt(end);
            // transform.Rotate(offset);

            render.size = new Vector2( 
            Vector3.Distance(start.position, end.position), .25f
            );

            var xToY = Quaternion.LookRotation(Vector3.forward, Vector3.right);

            var yToTarget = Quaternion.LookRotation(transform.forward, end.position - transform.position);

            transform.rotation = yToTarget * xToY;
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
