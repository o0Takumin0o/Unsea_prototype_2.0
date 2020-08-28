using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPopup : MonoBehaviour
{
    //public GameObject GuideTxt;
    public GameObject pushButtonText;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    private int dialogStage;
    private bool isInRange;
    private void Start()
    {
        //GuideTxt.SetActive(false);
        pushButtonText.gameObject.SetActive(false);
        dialogStage = 0;
        //dialogueManager = GameObject.Find("DialogManager").GetComponent<DialogueManager>();
    }
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key was pressed.");
            //GuideTxt.gameObject.SetActive(true);
            pushButtonText.gameObject.SetActive(false);
            //dialogueTrigger.TriggerDialogue();
            DialogueCtrl();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        //GuideTxt.gameObject.SetActive(true);
        if (collision.tag == "Player")
        {
            pushButtonText.gameObject.SetActive(true);
            isInRange = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {         
            pushButtonText.gameObject.SetActive(false);
            isInRange = false;
            //dialogManager.EndDialogue();
            dialogStage = 0;

        }
    }
    void DialogueCtrl()
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


        /*if (dialogueStage == 0)
        {
            dialogueTrigger.TriggerDialogue();
            dialogueStage = 1;
        }
        if (dialogueStage == 1)
        {
            dialogueManager.DisplayNextSentence();
        }*/
    }
}
