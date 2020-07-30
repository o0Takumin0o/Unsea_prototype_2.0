using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
[SerializeField]
public class EnemyCtrl : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    public GameObject Player;
    PlayerCtrl playerCtrl;
    public SlowTime slowTime;
    [Space(10)]
    public Transform[] patrolPoints;
    [Space(10)]
    public Transform pathHolder;
    
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
    

    void Awake()//protected override
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;//set speed of agent
        anim = GetComponent<Animator>();
        MoveToNextPatrolPoint();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }

    void Start()
    {
        anim.SetInteger("Stage", 0);//use when has model
        viewAngle = spotlight.spotAngle;
        originalSpotlightColour = spotlight.color;
    }

    public void OnTriggerEnter(Collider hitCollider)
    {
        if (hitCollider.tag == "Player")
        {
            navMeshAgent.SetDestination(Player.transform.position);
        }
    }
    
    public bool CanSeePlayer()
    {
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

    public void EmenyDetection()
    {
        if (CanSeePlayer())
        {
            playerVisibleTimer += Time.deltaTime;
            navMeshAgent.speed = RunSpeed;
            navMeshAgent.SetDestination(Player.transform.position);
            anim.SetInteger("Stage", 2);

        }
        else
        {
            playerVisibleTimer -= Time.deltaTime;
            navMeshAgent.speed = speed;//set speed of agent
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

}
