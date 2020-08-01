using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform PlayerTransform;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {//move camera follow player
        Vector3 desiredPosition = PlayerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(PlayerTransform);
    }
}
