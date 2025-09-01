using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ����ս��״̬

public class SkeletonBattleState : EnemyState
{
    private Transform player; // �������
    private Enemy_Skeleton enemy; // ���ñ���
    private int moveDir; // �ƶ�����

    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Enter Battle State");

        player = PlayerManager.instance.player.transform; // ��ȡ�������
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // ��⵽���ʱ������ս����ʱ
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;

            // ����ڹ����������ҿɹ������л�������״̬
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            // ����뿪�󣬼�ʱ����������Զ�л�idle
            if (stateTimer <= 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 10)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
            else
            {
                stateTimer -= Time.deltaTime;
            }
        }

        // �������λ�õ�������
        if (player.position.x >= enemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        // ����ҷ����ƶ�
        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }


    // �ж��Ƿ���Թ���

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttack + enemy.attackCooldown)
        {
            enemy.lastTimeAttack = Time.time;
            return true;
        }
        Debug.Log("������ȴ��");

        return false;
    }
}