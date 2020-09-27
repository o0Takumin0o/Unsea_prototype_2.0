using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{// put in item that can be pick up
    //public GameObject DestroyParticle;
    float speed = 2.0f;
    public GameObject DestroyParticle;

    void Update()
    {//transform.Rotate(speed, speed, speed);
        transform.Rotate(0, speed,0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            DestroyEffect();
            Destroy(gameObject);
        }
    }
    void DestroyEffect()
    {
        GameObject DestroyEffect = (GameObject)Instantiate(DestroyParticle, transform.position, Quaternion.identity);
        Destroy(DestroyEffect, 3f);
    }

}
