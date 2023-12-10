using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static GameManager;

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
    public LayerMask noiseLayer;

    [Header("Navigation")]
    public NavMeshAgent navAgent;
    public Transform[] patrolPoints;

    [Header("Animation")]
    public Animator enemyAnim;

    [Header("Invisibility")]
    public bool isInvis;
    public GameObject enemyModel;


    private void Start()
    {
        SwitchState(new EnemyPatrolState(this));
    }

    public void ShiftInvisibility(bool invis)
    {
        isInvis = invis;
        enemyModel.SetActive(invis);
    }

    public void UpdateLastHeard(Noise newNoise)
    {
        lastHeard.DestroyNoise();
        lastHeard = newNoise;
    }

    public void CheckForPlayer()
    {
        Collider[] targets = Physics.OverlapSphere(gm.enemies[0].transform.position, gm.enemies[0].killRadius);

        if (targets.Length > 0)
        {
            SwitchState(new EnemyAttackState(this));
        }
    }

    public void CheckForSound(Vector3 position)
    {
        Collider[] sounds = Physics.OverlapSphere(gm.enemies[0].transform.position, gm.enemies[0].runHearRadius, noiseLayer);

        if (sounds.Length > 0)
        {
            TravelToSound(position);
        }
    }

    public void TravelToSound(Vector3 position)
    {
        navAgent.SetDestination(position);
    }
}
