// Assets\Scripts\Player\PlayerWallSlideState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家滑墙状态
/// </summary>
public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 跳墙输入
        if (Input.GetKeyDown(KeyCode.K))
        {
            stateMachine.ChangeState(Player.wallJump);
            return;
        }

        // 离开墙体或反方向输入，切回idle
        if (!Player.IsWallDetected())
            stateMachine.ChangeState(Player.idleState);

        if (xInput != 0 && Player.facingDir * xInput < 0)
            stateMachine.ChangeState(Player.idleState);

        // 控制下滑速度
        if (yInput < 0)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y * Player.slideSpeed);

        // 落地切回idle
        if (Player.IsGroundDetected())
            stateMachine.ChangeState(Player.idleState);
    }
}