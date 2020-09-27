using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutSceenTriger : MonoBehaviour
{
    CameraFollowCutScene cameraFollowCutScene;

    private void Start()
    {
        cameraFollowCutScene = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollowCutScene>();
    }
    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "CutsceenTriger")
        {
            cameraFollowCutScene.InCutSceneRange = true;
        }
    }
    private void OnTriggerExit(Collider hitCollider)
    {
        if (hitCollider.tag == "CutsceenTriger")
        {
            cameraFollowCutScene.InCutSceneRange = false;
        }
    }
}
