using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    public EnemyPatrolState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.activeState = eState.Patrolling;
    }

    public override void Tick()
    {
        CheckTargetDistance();
    }

    public override void Exit()
    {

    }
}
