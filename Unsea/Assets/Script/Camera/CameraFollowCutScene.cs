using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCutScene : MonoBehaviour
{
    Transform PlayerTransform;
    public Transform objectiveTransform;
    //public Transform HammerTransform;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    //public Vector3 CutsceenOffset;
    Transform targetTransform;
    public bool InCutSceneRange;

    private void Start()
    {
        PlayerTransform = GameObject.Find("Player").GetComponent<Transform>();
        InCutSceneRange = false;
    }
    void FixedUpdate()
    {//move camera follow player
        changeCameraTarget();
        Vector3 desiredPosition = PlayerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(PlayerTransform);
        transform.LookAt(targetTransform);
    }
    void changeCameraTarget()
    {
        if (Input.GetKey(KeyCode.F))
        {
            targetTransform = objectiveTransform;
        }
        /*else if (InCutSceneRange == true)
        {
            offset = CutsceenOffset;
            targetTransform = HammerTransform;
            Debug.Log("InCutSceneRange == true");
        }*/
        else
            targetTransform = PlayerTransform;
    }

}
