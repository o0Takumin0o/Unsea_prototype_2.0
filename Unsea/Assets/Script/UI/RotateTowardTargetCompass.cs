using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardTargetCompass : MonoBehaviour
{
    public Transform target;
    //public float speed = 5f; every thing taht comemt out is for 3d direction
    void Update()
    {
        /*Vector3 direction = target.position = transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed);
        */
        Vector3 TargerPosition = new Vector3(target.transform.position.x,
                                        transform.position.y,
                                        target.transform.position.z);
        transform.LookAt(TargerPosition);
    }
}
