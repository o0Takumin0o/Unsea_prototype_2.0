using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    Collector Collector;
    private int dialogStage;
    public int ItemNeed;
    bool onetime = false;
    // Start is called before the first frame update
    void Start()
    {
        //dialogStage = 0;
        Collector = GameObject.Find("CollectorManager").GetComponent<Collector>();
        dialogStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemNeed == Collector.mainPoint && !onetime)
        {
            DialogueEventCtrl();
            onetime = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.DisplayNextSentence();
        }
    }

    void DialogueEventCtrl()
    {
        dialogueTrigger.TriggerDialogue();
        /*if(Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.DisplayNextSentence();
        }*/

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
    }
}
