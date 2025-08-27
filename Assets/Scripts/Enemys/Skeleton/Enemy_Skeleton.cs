using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 骷髅敌人，具体敌人类型

public class Enemy_Skeleton : Enemy
{
    #region States

    public SkeletonIdleState idleState { get; private set; } // 待机状态
    public SkeletonMoveState moveState { get; private set; } // 移动状态
    public SkeletonBattleState battleState { get; private set; } // 战斗状态
    public SkeletonAttackState attackState { get; private set; } // 攻击状态
    public SkeletonStunnedState stunnedState { get; private set; } // 眩晕状态

    #endregion

    protected override void Awake()
    {
        base.Awake();

        // 初始化所有状态
        moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        idleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        battleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        attackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
        stunnedState = new SkeletonStunnedState(this, stateMachine, "Stun", this);
    }

    protected override void Start()
    {
        base.Start();

        // 设置初始状态为idle
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        
    
    }
    public override bool CanBeStunned()
    {
        if (base.CanBeStunned())
        {
            // 如果可以被眩晕，切换到眩晕状态
            stateMachine.ChangeState(stunnedState);
            return true;
        }

        return false; // 如果不能被眩晕，返回false
    }
}