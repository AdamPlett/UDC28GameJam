<<<<<<< Updated upstream
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
=======
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
    [Range(0,100)] public float detection;
    public float runHearRadius;
    public float walkHearRadius;
    public float crouchHearRadius;
    public float killRadius;
    public Noise lastHeard;

    [Header("Navigation")]
    public NavMeshAgent navAgent;
    public Transform[] patrolPoints;

    [Header("Animation")]
    public Animator enemyAnim;

    private void Start()
    {
        SwitchState(new EnemyPatrolState(this));
    }

    public void UpdateLastHeard(Noise newNoise)
    {
        lastHeard.DestroyNoise();
        lastHeard = newNoise;
    }
}
>>>>>>> Stashed changes
