using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Narrator : MonoBehaviour
{
    //public GameObject pushButtonText;
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    public GameObject fadeOutScreen;
    //private int dialogStage;
    //private bool isInRange;
    private void Start()
    {
        //dialogueTrigger.TriggerDialogue();
        StartCoroutine(StartDialog());
        fadeOutScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueManager.DisplayNextSentence();
            //DialogueCtrl();
        }
        if (dialogueManager.endDialog == true)
        {
            fadeOutScreen.SetActive(true);
            StartCoroutine(GoToTitleScreen());
        }
    }
    IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(4);
        dialogueTrigger.TriggerDialogue();
    }
    IEnumerator GoToTitleScreen()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
