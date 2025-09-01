using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���õ������״̬����

public class SkeletonGroundedState : EnemyState
{
    protected Enemy_Skeleton enemy; // ���ñ���
    protected Transform player; // �������

    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.instance.player.transform; // ��ȡ�������
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // ��⵽��һ����ܽ�ʱ�л���ս��״̬
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}