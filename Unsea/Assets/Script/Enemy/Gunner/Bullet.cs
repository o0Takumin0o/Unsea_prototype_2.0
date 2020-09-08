using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   //still not work
    //will be use to spawn and move bullet to player
    Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
     Animator anim;
    Vector3 offset = new Vector3(0, 3, 0);
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Stage", 1);
    }
    public void Seek (Transform Player)
    {
       
        target = Player;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position + offset - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            //anim.SetInteger("Stage", 1);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget()
    {
        //Instantiate(impactEffect, transform.position, transform.rotation);
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetInteger("Stage", 1);
            
        }
    }
}
