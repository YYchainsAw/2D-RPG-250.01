using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 骷髅地面相关状态基类

public class SkeletonGroundedState : EnemyState
{
    protected Enemy_Skeleton enemy; // 骷髅本体
    protected Transform player; // 玩家引用

    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform; // 获取玩家引用
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 检测到玩家或距离很近时切换到战斗状态
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}