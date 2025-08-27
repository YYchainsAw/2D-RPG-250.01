using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 骷髅移动状态

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Move State");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 持续向前移动
        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

        Debug.Log("IsWallDetected: " + enemy.IsWallDetected() + ", IsGroundDetected: " + enemy.IsGroundDetected());

        // 遇到墙或无地面时翻转并切回idle
        if (enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
