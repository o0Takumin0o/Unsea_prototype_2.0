using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabArmorAnim : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("Stage", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("Stage", 1);
        }
        else anim.SetInteger("Stage", 0);
    }
}
