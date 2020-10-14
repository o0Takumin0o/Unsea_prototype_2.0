using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
    Collider Collider;
    public GameObject tutorialWindow;
    public GameObject IngameUI;
    public Animator tutorialAnim;
    public GameObject BackGroundImage;
    GameObject player;
    //PauseMenu PauseMenu;
    SlowTime slowTime;
    bool ActiveTutorial = false;
    bool oneTime = false;
    public string NameOfTutorial;
    int trigger;
    int IsTrigger;
    // Start is called before the first frame update
    void Start()
    {
        //PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        slowTime = GameObject.Find("TimeManager").GetComponent<SlowTime>();
        player = GameObject.Find("Player");
        Collider = GetComponent<Collider>();
        trigger = PlayerPrefs.GetInt("IsTrigger" + NameOfTutorial.ToString());
        if (trigger == 1)
        {
            Collider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ActiveTutorial == true&& Input.GetKeyDown(KeyCode.E))
        {
            tutorialAnim.SetInteger("Stage", 1);
            //tutorialWindow.SetActive(false);
            IngameUI.SetActive(true);
            //PauseMenu.Resume();
            ActiveTutorial = false;
            slowTime.slowMotionSpeed = 1f;
            player.SetActive(true);
            StartCoroutine(CloseTutorial());
            Time.fixedDeltaTime = 0.02f;
            BackGroundImage.SetActive(false);
            PlayerPrefs.SetInt("IsTrigger" + NameOfTutorial.ToString(),1);
        }

    }
    IEnumerator CloseTutorial()
    {
        yield return new WaitForSeconds(3);
        tutorialWindow.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& oneTime == false)
        {
            tutorialAnim.SetInteger("Stage", 0);
            //tutorialWindow.SetActive(true);
            IngameUI.SetActive(false);
            //PauseMenu.Pause();
            ActiveTutorial = true;
            oneTime = true;
            player.SetActive(false);
            //Time.fixedDeltaTime = slowTime.slowMotionSpeed * 0.02f;
            slowTime.slowMotionSpeed = 0.05f;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            tutorialWindow.SetActive(true);
            BackGroundImage.SetActive(true);
        }
    }
}
