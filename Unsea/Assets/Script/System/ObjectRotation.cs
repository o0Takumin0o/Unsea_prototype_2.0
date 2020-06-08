using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public ParticleSystem deathParticle;
    float speed = 2.0f;
    
    void Update()
    {
        //transform.Rotate(speed, speed, speed);
        transform.Rotate(0, speed,0);
    }
    void Destroy()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);

    }
}
