using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform refferentTransform;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
        transform.position = refferentTransform.position;
    }
}
