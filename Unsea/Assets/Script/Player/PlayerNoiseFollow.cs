using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoiseFollow : MonoBehaviour
{
    Transform PlayerTransform;

    public float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {//move camera follow player
        Vector3 desiredPosition = PlayerTransform.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.Translate(smoothedPosition);
    }
}
