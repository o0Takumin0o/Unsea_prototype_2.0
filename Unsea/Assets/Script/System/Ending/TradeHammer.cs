using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeHammer : MonoBehaviour
{
    //EndingCollecter endingCollecter;
    public Animator WoodAnim;
    //CameraFollowCutScene cameraFollowCutScene;
    private bool isInRange;
    public GameObject pushButtonText;
    public GameObject ItemNeedText;
    public GameObject Isopodbig;
    public GameObject IsopodSeasaw;
    public bool HasEnoughItem = false;
    public GameObject MainCamera;
    public GameObject HammerCamera;
    public GameObject QuestionMask;
    public GameObject TradeHammerEffect;
    SoundFx soundFX;

    // Start is called before the first frame update
    void Start()
    {
        pushButtonText.gameObject.SetActive(false);
        ItemNeedText.gameObject.SetActive(false);
        //anim = GetComponent<Animator>();
        WoodAnim.SetInteger("Stage", 0);
        //endingCollecter = GameObject.Find("CollectorManager").GetComponent<EndingCollecter>();
        Isopodbig.SetActive(false);
        IsopodSeasaw.SetActive(false);
        //cameraFollowCutScene = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollowCutScene>();
        HammerCamera.SetActive(false);
        TradeHammerEffect.SetActive(false);
        soundFX = GameObject.Find("SoundCtrl").GetComponent<SoundFx>();

    }

    // Update is called once per frame
    void Update()
    {
        if (HasEnoughItem == true && isInRange && Input.GetKeyDown(KeyCode.E))
        {
            pushButtonText.gameObject.SetActive(false);
            //WoodAnim.SetInteger("Stage", 1);
            StartCoroutine(TradeHammerAnim());
            //Isopodbig.SetActive(true);
            //IsopodSeasaw.SetActive(true);
            QuestionMask.SetActive(false);
            soundFX.CollectedAllpointSound();
            TradeHammerEffect.SetActive(true);
            StartCoroutine(tradeHammerEffectDiasble());
        }
        if (HasEnoughItem == false && isInRange && Input.GetKeyDown(KeyCode.E))
        {
            pushButtonText.gameObject.SetActive(false);
            ItemNeedText.gameObject.SetActive(true);
            QuestionMask.SetActive(false);
            
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            pushButtonText.gameObject.SetActive(true);
            isInRange = true;
            HammerCamera.SetActive(true);
            MainCamera.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            pushButtonText.gameObject.SetActive(false);
            ItemNeedText.gameObject.SetActive(false);
            isInRange = false;
            MainCamera.SetActive(true);
            HammerCamera.SetActive(false);
            QuestionMask.SetActive(true);
        }
    }
    IEnumerator tradeHammerEffectDiasble()
    {
        yield return new WaitForSeconds(2);
        TradeHammerEffect.SetActive(false);
    }
    IEnumerator TradeHammerAnim()
    {
        yield return new WaitForSeconds(1);
        WoodAnim.SetInteger("Stage", 1);
        Isopodbig.SetActive(true);
        IsopodSeasaw.SetActive(true);
    }
}
