using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    public GameObject pushButtonText;
    public GameObject NeedHammerText;
    public GameObject questionmark;
    EndingCollecter endingCollecter;
    public Animator anim;
    public Animator playerAnim;
    int Stage;
    private bool isInRange;
    public bool hasHammer;
    public bool GoodEnd = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pushButtonText.gameObject.SetActive(false);
        //anim = GetComponent<Animator>();
        anim.SetInteger("Stage", 0);
        endingCollecter = GameObject.Find("CollectorManager").GetComponent<EndingCollecter>();
        NeedHammerText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (hasHammer == true)
            {
                pushButtonText.gameObject.SetActive(false);
                //playerAnim.SetInteger("Stage", 3);
                anim.SetInteger("Stage", 1);
                GoodEnd = true;
                Debug.Log("GoodEnd");
                questionmark.SetActive(false);
            }
            if (hasHammer == false)
            {
                pushButtonText.gameObject.SetActive(false);
                NeedHammerText.SetActive(true);
                questionmark.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            pushButtonText.gameObject.SetActive(true);
            isInRange = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        NeedHammerText.SetActive(false);
        pushButtonText.gameObject.SetActive(false);
        questionmark.SetActive(true);
    }

}
