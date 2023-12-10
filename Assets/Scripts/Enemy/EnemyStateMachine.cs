using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    public eState activeState;

    [Header("Movement")]
    public float moveSpeed;
    public float chaseSpeed;

    [Header("Detection")]
    public float detection;
    public float hearRadius;
    public float seeRadius;
    public Transform lastHeard;

    [Header("Navigation")]
    public NavMeshAgent navAgent;
    public Transform[] patrolPoints;

    private void Start()
    {
        SwitchState(new EnemyPatrolState(this));
    }
}
