using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    public GameObject pushButtonText;
    public Animator anim;
    public int Stage;
    private bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        pushButtonText.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
        anim.SetInteger("Stage", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            pushButtonText.gameObject.SetActive(false);
            anim.SetInteger("Stage", 1);
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
}
