using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearchState : EnemyBaseState
{
    public EnemySearchState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.activeState = eState.Searching;
        stateMachine.enemyAnim.Play("Run");
    }

    public override void Tick()
    {
        if (stateMachine.navAgent.remainingDistance < 0.5f)
        {
            stateMachine.SwitchState(new EnemyScoutState(stateMachine));
        }
    }

    public override void Exit()
    {

    }
}
