using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    //public GameObject pushButtonText;
    public DialogueTrigerEnding dialogueTrigger;
    public DialogueManagerEnding dialogueManager;
    //private int dialogStage;
    //private bool isInRange;
    private void Start()
    {
        //GuideTxt.SetActive(false);
        //pushButtonText.gameObject.SetActive(false);
        //dialogStage = 0;
        dialogueTrigger.TriggerDialogue();
        //dialogueManager = GameObject.Find("DialogManager").GetComponent<DialogueManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.DisplayNextSentence();
            //DialogueCtrl();
        }
    }
    
}
