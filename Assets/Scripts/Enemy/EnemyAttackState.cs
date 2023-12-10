using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.activeState = eState.Attacking;

        Attack();
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {

    }
}
