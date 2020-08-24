using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{// put in item that can be pick up
    public GameObject DestroyParticle;
    float speed = 2.0f;
    
    void Update()
    {//transform.Rotate(speed, speed, speed);
        transform.Rotate(0, speed,0);
    }
    
    public void OnDestroy()
    {
        GameObject DestroyEffect = (GameObject) Instantiate(DestroyParticle, transform.position, Quaternion.identity);
        Destroy(DestroyEffect, 3f);
    }
}
