using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 骷髅待机状态

public class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Idle State");

        stateTimer = enemy.idleTime; // 设置待机时间
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 待机时间结束后切换到移动状态
        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}