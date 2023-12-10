using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoutState : EnemyBaseState
{
    public EnemyScoutState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    private Vector3 prevTarget;

    public override void Enter()
    {
        stateMachine.activeState = eState.Scouting;

        prevTarget = stateMachine.navAgent.destination;

        stateMachine.navAgent.isStopped = true;
        stateMachine.enemyAnim.Play("Search");
    }

    public override void Tick()
    {
        stateMachine.detection -= Time.deltaTime * 10f;

        if(stateMachine.detection <= 0)
        {
            stateMachine.navAgent.isStopped = false;
            stateMachine.navAgent.SetDestination(prevTarget);

            stateMachine.SwitchState(new EnemyPatrolState(stateMachine));
        }
    }

    public override void Exit()
    {

    }
}
