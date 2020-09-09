using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//[SerializeField]
public class EnemyCtrl : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    public GameObject Player;
    PlayerCtrl playerCtrl;
    public SlowTime slowTime;
    public Transform LookAt;
    public float LookRotationSpeed = 5f;
    [Space(10)]
    public Transform pathHolder;
    public Transform[] patrolPoints;

   [Header("Movement")]
    public float speed; //speed of npc
    public float RunSpeed;
    [Header("Sense")]
    public float viewDistance;
    public Light spotlight;
    Color originalSpotlightColour;
    public float timeToSpotPlayer = 2f;
    public LayerMask viewMask;

    float viewAngle;
    [HideInInspector]
    public float playerVisibleTimer;
    float distanceToPlayer = Mathf.Infinity;
    public static event System.Action OnGuardHasSpottedPlayer;
    private int currentControlPointIndex = 0;
    public Vector3 PlayerLocation;
    [HideInInspector]
    public float waitToRespawn;
    MusicCtrl musicCtrl;

    public GameObject StopTarget;
    GameObject Target;
    /*void Awake()//protected override
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;//set speed of agent
        anim = GetComponent<Animator>();
        MoveToNextPatrolPoint();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        musicCtrl = GameObject.Find("SoundCtrl").GetComponent<MusicCtrl>();
        originalSpotlightColour = spotlight.color;
    }*/

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;//set speed of agent
        anim = GetComponent<Animator>();
        MoveToNextPatrolPoint();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        musicCtrl = GameObject.Find("SoundCtrl").GetComponent<MusicCtrl>();
        originalSpotlightColour = spotlight.color;
        anim.SetInteger("Stage", 0);//use when has model
        viewAngle = spotlight.spotAngle;

    }
    

    public void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Player")
        {
            Respawn();
            /*navMeshAgent.SetDestination(Player.transform.position);
            LookAtPlayer();*/
            anim.SetInteger("Stage", 2);
        }
        //neet to make enemy go to noise
        if (hitCollider.tag == "NoiseMakerTrap")
        {
            navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("NoiseMakerTrap").transform.position);
            
            anim.SetInteger("Stage", 1);
            spawnTarget();

        }
        if (hitCollider.tag == "NoiseMaker")
        {
            navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("NoiseMaker").transform.position);

            anim.SetInteger("Stage", 1);

        }

        if (hitCollider.tag == "PlayerNoise")
        {
            navMeshAgent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            anim.SetInteger("Stage", 1);
        }

        if (hitCollider.tag == "StopTarget")
        {
            //anim.SetInteger("Stage", 0);
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Destroy(Target);

            StartCoroutine(resetNavmesh());
        }
    }

   
    IEnumerator resetNavmesh()
    {
        yield return new WaitForSeconds(7);
        //anim.SetInteger("Stage", 1);
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
    }

    void spawnTarget()
    {
        Target = (GameObject)Instantiate(StopTarget, GameObject.FindGameObjectWithTag("NoiseMakerTrap").transform.position, Quaternion.identity);
    }

    public bool CanSeePlayer()
    {//need animater to sea player
        if (playerCtrl.PlayerVisible == true && Vector3.Distance(transform.position, PlayerLocation) < viewDistance)
        //if player in raycast angle = AI can see player
        {

            Vector3 dirToPlayer = (PlayerLocation - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, PlayerLocation, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void EnemyDetection()
    {
        if (CanSeePlayer())
        {
            playerVisibleTimer += Time.deltaTime;
            navMeshAgent.speed = RunSpeed;
            navMeshAgent.SetDestination(Player.transform.position);
            anim.SetInteger("Stage", 2);
            musicCtrl.PlayPanicSound();
        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
            navMeshAgent.speed = speed;//set speed of agent
            musicCtrl.StopPanicSound();
        }

        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
        spotlight.color = Color.Lerp(originalSpotlightColour, Color.red, playerVisibleTimer / timeToSpotPlayer);

        if (playerVisibleTimer >= timeToSpotPlayer)
        {//GameObject.Find("Player").SendMessage("Finnish");
            if (OnGuardHasSpottedPlayer != null)
            {
                OnGuardHasSpottedPlayer();
                
                slowTime.Endlevel = false;

                if (waitToRespawn <= 0f)
                {
                    Respawn();
                    slowTime.TimeSpeedReset();
                }
                waitToRespawn  -= Time.deltaTime;
            }
        }
    }

    void OnDrawGizmos()
    {//make waypoint visible 

        //in order to make gismos vivible parthholder nood a child object in it and put that child object in partrol point
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);//waypoint
            Gizmos.DrawLine(previousPosition, waypoint.position);//line to conect waypoint
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);

        Gizmos.DrawSphere(LookAt.position, .5f);
    }

    public void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            navMeshAgent.destination = patrolPoints[currentControlPointIndex].position;

            currentControlPointIndex++;
            currentControlPointIndex %= patrolPoints.Length;
        }
       
    }
    public void Respawn()
    {//reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LookAtTarget()
    {      
        Vector3 direction = LookAt.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, LookRotationSpeed * Time.deltaTime);
    }
    /*public void LookAtPlayer()
    {
        Vector3 direction = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, LookRotationSpeed * Time.deltaTime);
    }*/

}
