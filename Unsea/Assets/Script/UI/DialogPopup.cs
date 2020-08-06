using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopup : MonoBehaviour
{
    public GameObject GuideTxt;
    public GameObject pushButtonText;
    private bool isInRange;
    private void Start()
    {
        GuideTxt.SetActive(false);
        pushButtonText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key was pressed.");
            GuideTxt.gameObject.SetActive(true);
            pushButtonText.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        //GuideTxt.gameObject.SetActive(true);
        if (collision.tag == "Player")
        {
            pushButtonText.gameObject.SetActive(true);
            isInRange = true;
            /*if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E key was pressed.");
                GuideTxt.gameObject.SetActive(true);
                pushButtonText.gameObject.SetActive(false);
            }*/
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            GuideTxt.gameObject.SetActive(false);
            pushButtonText.gameObject.SetActive(false);
            isInRange = false;
            //pushButtonText.gameObject.SetActive(false);
            //GuideTxt.gameObject.SetActive(false);
        }
    }
    /*void DialogTutorial()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key was pressed.");
            GuideTxt.gameObject.SetActive(true);
            pushButtonText.gameObject.SetActive(false);
        }
    }*/
}
