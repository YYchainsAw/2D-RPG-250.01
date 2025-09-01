using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 骷髅战斗状态

public class SkeletonBattleState : EnemyState
{
    private Transform player; // 玩家引用
    private Enemy_Skeleton enemy; // 骷髅本体
    private int moveDir; // 移动方向

    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Battle State");

        player = PlayerManager.instance.player.transform; // 获取玩家引用
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 检测到玩家时，重置战斗计时
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;

            // 玩家在攻击距离内且可攻击则切换到攻击状态
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            // 玩家离开后，计时结束或距离过远切回idle
            if (stateTimer <= 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 10)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
            else
            {
                stateTimer -= Time.deltaTime;
            }
        }

        // 根据玩家位置调整朝向
        if (player.position.x >= enemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        // 向玩家方向移动
        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }


    // 判断是否可以攻击

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttack + enemy.attackCooldown)
        {
            enemy.lastTimeAttack = Time.time;
            return true;
        }
        Debug.Log("攻击冷却中");

        return false;
    }
}