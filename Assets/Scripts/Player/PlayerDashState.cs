using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家冲刺状态
/// </summary>
public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    /// <summary>
    /// 进入冲刺状态，设置冲刺持续时间
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        Player.skill.clone.CreateClone(Player.transform); // 创建分身

        stateTimer = Player.dashDuration; // 设置冲刺持续时间
    }

    /// <summary>
    /// 退出冲刺状态，停止水平速度
    /// </summary>
    public override void Exit()
    {
        base.Exit();

        Player.SetVelocity(0, rb.velocity.y); // 退出时停止水平速度
    }

    /// <summary>
    /// 冲刺状态每帧更新
    /// </summary>
    public override void Update()
    {
        base.Update();

        // 冲刺过程中如果在空中且检测到墙体，切换到滑墙状态
        if (!Player.IsGroundDetected() && Player.IsWallDetected())
            stateMachine.ChangeState(Player.wallSlide);

        // 持续设置冲刺速度
        Player.SetVelocity(Player.dashSpeed * Player.dashDir, 0);

        // 冲刺时间结束后切换到idle
        if (stateTimer < 0)
            stateMachine.ChangeState(Player.idleState);
    }
}