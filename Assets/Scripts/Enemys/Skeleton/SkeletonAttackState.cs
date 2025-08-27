using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���ù���״̬

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

        // ��¼�ϴι���ʱ��
        enemy.lastTimeAttack = Time.time;
    }

    public override void Update()
    {
        base.Update();

        // ����ʱ�ٶȹ���
        enemy.SetZeroVelocity();

        // �����¼��������л�ս��״̬
        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}