// Assets\Scripts\Player\PlayerPrimaryAttackState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家主攻击状态（连击）
/// </summary>
public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter; // 连击计数
    private float lastTimeAttacked; // 上次攻击时间
    private float comboWindow = 1; // 连击窗口时间

    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        xInput = 0; // 重置水平输入

        // 超过连击数或超时则重置
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;

        Player.anim.SetInteger("ComboCounter", comboCounter);

        // 计算攻击方向
        float attackDir = Player.facingDir;
        if (xInput != 0)
            attackDir = xInput;

        // 设置攻击时的位移
        Player.SetVelocity(Player.attackMovement[comboCounter].x * attackDir, Player.attackMovement[comboCounter].y);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        // 攻击后短暂忙碌
        Player.StartCoroutine("BusyFor", .1f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        // 攻击后速度归零
        if (stateTimer < 0)
            Player.SetZeroVelocity();

        // 动画事件触发后切换回idle
        if (triggerCalled)
            stateMachine.ChangeState(Player.idleState);
    }
}