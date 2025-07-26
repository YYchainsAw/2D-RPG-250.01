// Assets\Scripts\Player\PlayerWallJumpState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家墙跳状态
/// </summary>
public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = .4f; // 墙跳持续时间
        Player.SetVelocity(5 * -Player.facingDir, Player.jumpForce); // 墙跳初速度
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 墙跳时间结束切换到空中
        if (stateTimer < 0)
            stateMachine.ChangeState(Player.airState);

        // 落地切换到idle
        if (Player.IsGroundDetected())
            stateMachine.ChangeState(Player.idleState);
    }
}