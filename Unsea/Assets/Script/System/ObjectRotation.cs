using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{// put in item that can be pick up
    public GameObject DestroyParticle;
    float speed = 2.0f;
    [SerializeField]
    float height = 0.5f;

    [SerializeField]
    float period = 1;

    private Vector3 initialPosition;
    private float offset;

    private void Start()
    {
        initialPosition = transform.position;

        offset = 1 - (Random.value * 2);
    }
    void Update()
    {//transform.Rotate(speed, speed, speed);
        transform.Rotate(0, speed,0);
        
        transform.position = initialPosition - Vector3.up * Mathf.Sin((Time.time + offset) * period) * height;
    }
    
    public void OnDestroy()
    {
        GameObject DestroyEffect = (GameObject) Instantiate(DestroyParticle, transform.position, Quaternion.identity);
        Destroy(DestroyEffect, 3f);
    }
}
