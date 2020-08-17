using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : EnemyCtrl
{
    void Update()
    {
        NpcAction();//what npc will do
        EnemyDetection();
        PlayerLocation = GameObject.Find("Player").transform.position;
        //position of player use in can see player
    }
    void NpcAction()
    {//move to player when detect player
        if (navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position,
                this.transform.position);

            bool patrol = false;
            bool follow = CanSeePlayer();

            if (follow)
            {
                EnemyDetection();
            }

            patrol = !follow && patrolPoints.Length > 0;

            if ((!follow) && !patrol)
            {
                navMeshAgent.SetDestination(transform.position);
                anim.SetInteger("Stage", 2);
            }

            if (patrol)
            {
                if (!navMeshAgent.pathPending && navMeshAgent.
                    remainingDistance < 0.5f)
                {
                    MoveToNextPatrolPoint();
                    anim.SetInteger("Stage", 1);
                }
                if (navMeshAgent.remainingDistance < 0.01f)
                {
                    anim.SetInteger("Stage", 0);
                    LookAtTarget();
                }
            }

        }
    }
}
