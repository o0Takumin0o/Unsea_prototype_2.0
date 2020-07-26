using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopup : MonoBehaviour
{
    public GameObject GuideTxt;
    private void Start()
    {
        GuideTxt.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            GuideTxt.gameObject.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            GuideTxt.gameObject.SetActive(false);
        }
    }
}
