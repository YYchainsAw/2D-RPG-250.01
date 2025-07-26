using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ���õ��ˣ������������

public class Enemy_Skeleton : Enemy
{
    #region States

    public SkeletonIdleState idleState { get; private set; } // ����״̬
    public SkeletonMoveState moveState { get; private set; } // �ƶ�״̬
    public SkeletonBattleState battleState { get; private set; } // ս��״̬
    public SkeletonAttackState attackState { get; private set; } // ����״̬

    #endregion

    protected override void Awake()
    {
        base.Awake();

        // ��ʼ������״̬
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        battleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        attackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
    }

    protected override void Start()
    {
        base.Start();

        // ���ó�ʼ״̬Ϊidle
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}