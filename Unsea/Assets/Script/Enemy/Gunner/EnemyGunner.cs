using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGunner : EnemyCtrl 
{
  
    public float AttackDistance = 10.0f;

    public float FollowDistance = 20.0f;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;

    public float DamagePoints = 2.0f;

    public AudioClip ShootSound = null;
    
    private float fireCountdown = 0f;

    public SoundFx soundFX;

    void Update()
    {
        NpcAction();//what npc will do
        EnemyDetection();
        PlayerLocation = GameObject.Find("Player").transform.position;//position of player use in can see player
    }

    void NpcAction()
    {
        if (base.navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);

            bool shoot = false;
            bool patrol = false;
            bool follow = base.CanSeePlayer(); 

            if (follow)
            {//follow player
                float random = Random.Range(0.0f, 1.0f);
             
                if (playerVisibleTimer >= timeToSpotPlayer)
                {//shoot player
                    if (fireCountdown <= 0f)
                    {
                        Shoot();
                        soundFX.ShootSound();
                        //fireCountdown = 1f / fireRate;
                        //put shooting wvent here
                        fireCountdown = 1f / 1;
                    }
                    fireCountdown -= Time.deltaTime;
                }
                navMeshAgent.SetDestination(Player.transform.position);
                EnemyDetection();
            }

            patrol = !follow && !shoot && patrolPoints.Length > 0;

            if ((!follow || shoot) && !patrol)
            {
                navMeshAgent.SetDestination(transform.position);
                //anim.SetInteger("Stage", 1);
            }

            if (patrol)
            {
                if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
                {
                    MoveToNextPatrolPoint();
                    //anim.SetInteger("Stage", 1);
                }
                if (navMeshAgent.remainingDistance < 0.001f)
                {//stop walking animation when not have other point to move
                    //anim.SetInteger("Stage", 0);
                }
            }

        }
    }
    void Shoot()
    {
        Debug.Log("Shoot");
    }

    
}
