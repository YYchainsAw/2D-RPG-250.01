using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 骷髅攻击状态

public class SkeletonAttackState : EnemyState
{
    private Enemy_Skeleton enemy;

    public SkeletonAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        // 记录上次攻击时间
        enemy.lastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();

        // 攻击时速度归零
        enemy.SetZeroVelocity();

        // 动画事件触发后切回战斗状态
        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}