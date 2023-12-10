using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    public EnemyPatrolState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.activeState = eState.Patrolling;
        stateMachine.enemyAnim.Play("Walk");
    }

    public override void Tick()
    {
        if (stateMachine.navAgent.remainingDistance < 1f)
        {
            TravelToNextPoint();
        }
    }

    public override void Exit()
    {

    }
}
