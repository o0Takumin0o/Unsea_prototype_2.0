using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    private GameManager GM;
    [HideInInspector]
    public Animator animator;
    public Animator HidingAnimator;
    [Header("Movement")]
    public float moveSpeed = 8;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    float angle;
    float smoothInputMagnitude;
    float smoothMoveVelocity;
    Vector3 velocity;
    Rigidbody rigidbody;
    public Rigidbody Rigidbody { get => rigidbody; set => rigidbody = value; }
    bool disabled;

    [Header("Reference")]
    public Collector collector;
    public SubCollector subcCollector;
    public SlowTime slowTime;
    public Timer timer;
    EnemyCtrl enemyCtrl; 
    public SoundFx soundFX;
    //public PlayerSound playerSound;

    public event System.Action OnReachedEndOfLevel;
    [SerializeField]
    public bool LevelEnd = false;
    [SerializeField]
    public bool PlayerVisible = true;
    public GameObject playerNoise;
    [Header("UI")]
    public GameObject WinScreen;
    public GameObject GameplayUI;
    private float SoundCountdown = 0f;

    Game game;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        EnemyCtrl.OnGuardHasSpottedPlayer += Disable;
        game = GameObject.Find("Game").GetComponent<Game>();
        playerNoise.SetActive(false);
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
            animator.SetInteger("Stage", 1);
            playerNoise.SetActive(true);

        }
        else
        {
            animator.SetInteger("Stage", 0);
            SoundCountdown = 0;
            playerNoise.SetActive(false);
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
            HidingAnimator.SetInteger("FadeIN", 0);
        }
    }
    void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Finish_Goal")
        {
            Disable();
            WinScreen.SetActive(true);//active win screen
            GameplayUI.SetActive(false);//hide in game ui
            slowTime.Endlevel = true;//slowtime
            timer.levelEnd();//stop timer
            LevelEnd = true;
            //timer.ReachEndLevel = true;
            timer.BestTime60Sec();
            game.DeleteAllProgress();
            subcCollector.saveHightScore();
            timer.levelEnd();
            if (OnReachedEndOfLevel != null)
            {
                OnReachedEndOfLevel();
            }
            //GameObject.Find("Player").SendMessage("Finish_Goal");
            //GM.resetCheckPoint();
            game.ResetCheckpoint();
            //soundFX.WinLevel();
            //soundFX.CollectedAllpointSound();
            soundFX.WinLevel();
        }

        if (hitCollider.tag == "HidingSpots")
        {
            PlayerVisible = false;
            HidingAnimator.SetInteger("FadeIN", 1);
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
            //Debug.Log("subPointGet");
            Destroy(hitCollider.gameObject);
            soundFX.Pickup();
        }

        if (hitCollider.tag == "Bullet")
        {
            moveSpeed = 4;
            StartCoroutine(resetSpeed());
        }
        
    }
    IEnumerator resetSpeed()
    {
        yield return new WaitForSeconds(2);

        moveSpeed = 8;
    }
    public void TimeSpeedReset()
    {//reset time to defalt speed
        slowTime.Endlevel = false;
    }
}
