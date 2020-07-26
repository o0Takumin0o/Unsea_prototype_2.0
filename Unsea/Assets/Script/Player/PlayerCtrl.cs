using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    Animator animator;
    [Header("Movement")]
    public float moveSpeed = 7;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    float angle;
    float smoothInputMagnitude;
    float smoothMoveVelocity;
    Vector3 velocity;
    Rigidbody rigidbody;
    public Rigidbody Rigidbody { get => rigidbody; set => rigidbody = value; }
    bool disabled;

    [Header("Refferent")]
    public Collector collector;
    public SubCollector subcCollector;
    public SlowTime slowTime;
    public Timer timer;
    EnemyCtrl enemyCtrl; 
    public SoundFx soundFX;
    
    public event System.Action OnReachedEndOfLevel;
    [SerializeField]
    public bool LevelEnd = false;
    [SerializeField]
    public bool PlayerVisible = true;
    [Header("UI")]
    public GameObject WinScreen;
    public GameObject GameplayUI;
    private float SoundCountdown = 0f;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        EnemyCtrl.OnGuardHasSpottedPlayer += Disable;

        //slowTime = (SlowTime)FindObjectOfType(typeof(SlowTime)); //useto find code that been instance when change scene
    }
    void Update()
    {
        Vector3 inputDirection = Vector3.zero;
        if (!disabled)
        {
            inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            GetComponent<Rigidbody>().velocity = new Vector3(0, -5, 0);
        }

        float inputMagnitude = inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothInputMagnitude;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("Walk", 1);
                  
            if (SoundCountdown <= 0f)
            {
                soundFX.swimSound();
                SoundCountdown = 1.5f / 1;
            }
            SoundCountdown -= Time.deltaTime;
        }
        else
        {
            animator.SetInteger("Walk", 0);
            SoundCountdown = 0;
        }

    }

    void FixedUpdate()
    {
        Rigidbody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        Rigidbody.MovePosition(GetComponent<Rigidbody>().position + velocity * Time.deltaTime);
    }

    void Disable()
    {
        disabled = true;
    }

    void OnDestroy()
    {//if AI see more than ... sec. stop player movement
        EnemyCtrl.OnGuardHasSpottedPlayer -= Disable;
    }
    private void OnTriggerExit(Collider hitCollider)
    {
        if (hitCollider.tag == "HidingSpots")
        {
            PlayerVisible = true;
        }
    }
    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Finnish")
        {
            Disable();
            timer.levelEnd();//stop timer
            timer.ReachEndLevel = true;
            WinScreen.SetActive(true);//active win screen
            GameplayUI.SetActive(false);//hide in game ui
            slowTime.Endlevel = true;//slowtime      
            LevelEnd = true;

            if (OnReachedEndOfLevel != null)
            {
                OnReachedEndOfLevel();
            }
            GameObject.Find("Player").SendMessage("Finish_Goal");
        }

        if (hitCollider.tag == "HidingSpots")
        {
            PlayerVisible = false;
        }
        if (hitCollider.tag == "KeyItem")
        {
            collector.UpdatePoint();
            Debug.Log("pointGet");
            Destroy(hitCollider.gameObject);
            soundFX.Pickup();
        }
        if (hitCollider.tag == "CollectorItem")
        {
            subcCollector.UpdatecollectorPoint();
            Debug.Log("subPointGet");
            Destroy(hitCollider.gameObject);
            soundFX.Pickup();
        }

        if (hitCollider.tag == "Enemy")
        {
            GameObject.Find("Player").SendMessage("Finnish");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//reload current scene
            slowTime.Endlevel = true;
            timer.levelEnd();
        }
        if (hitCollider.tag == "Hearing")
        {
            enemyCtrl.EmenyDetection();
        }
    }
    public void TimeSpeedReset()
    {//reset time to defalt speed
        slowTime.Endlevel = false;
    }
}
