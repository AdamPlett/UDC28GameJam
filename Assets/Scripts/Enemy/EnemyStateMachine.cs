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

<<<<<<< Updated upstream
<<<<<<< Updated upstream
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

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
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
