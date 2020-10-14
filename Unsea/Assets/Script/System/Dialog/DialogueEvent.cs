using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    //public GameObject GuideTxt;
    //public GameObject pushButtonText;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    private int dialogStage;
    private bool isInRange;
    private void Start()
    {
        //GuideTxt.SetActive(false);
        //pushButtonText.gameObject.SetActive(false);
        //dialogStage = 0;
        //dialogueManager = GameObject.Find("DialogManager").GetComponent<DialogueManager>();
    }
    private void Update()
    {
        if (isInRange)
        {
            //Debug.Log("E key was pressed.");
            //GuideTxt.gameObject.SetActive(true);
            //pushButtonText.gameObject.SetActive(false);
            dialogueTrigger.TriggerDialogue();
            //DialogueCtrl();
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueManager.DisplayNextSentence();
            }
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        //GuideTxt.gameObject.SetActive(true);
        if (collision.tag == "Player")
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = false;
            //dialogManager.EndDialogue();
            dialogueManager.EndDialogue();
        }
    }
    /*void DialogueCtrl()
    {
        switch (dialogStage)
        {
            case 0:
                dialogueTrigger.TriggerDialogue();
                dialogStage = 1;
                break;

            case 1:
                dialogueManager.DisplayNextSentence();
                break;
        }
    }*/
}
