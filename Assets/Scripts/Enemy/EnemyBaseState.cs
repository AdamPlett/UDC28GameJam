using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static GameManager;

public enum eState { None, Patrolling, Searching, Chasing, Attacking, Wandering }

public abstract class EnemyBaseState : State
{
    protected readonly EnemyStateMachine stateMachine;

    private int patrolIndex = 0;

    private Transform targetLocation;
    private NavMeshAgent navAgent;
    private GameObject player;

    protected EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        navAgent = stateMachine.navAgent;
        player = gm.playerInstance;

        TravelToNextPoint();
    }

    protected void CheckTargetDistance()
    {
        if(stateMachine.activeState == eState.Patrolling)
        {
            if (navAgent.remainingDistance < 1f)
            {
                TravelToNextPoint();
            }
        }
    }

    protected void TravelToNextPoint()
    {
        patrolIndex = (patrolIndex + 1) % stateMachine.patrolPoints.Length;
        navAgent.SetDestination(stateMachine.patrolPoints[patrolIndex].position);
    }

    protected void TravelToSound(Transform soundTransform)
    {
        navAgent.SetDestination(soundTransform.position);
    }

    protected void Attack()
    {
        // Kill the fucking player
        // Make them shit their pants
    }
}