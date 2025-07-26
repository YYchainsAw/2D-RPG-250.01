// Assets\Scripts\Player\PlayerWallSlideState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��һ�ǽ״̬
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

        // ��ǽ����
        if (Input.GetKeyDown(KeyCode.K))
        {
            stateMachine.ChangeState(Player.wallJump);
            return;
        }

        // �뿪ǽ��򷴷������룬�л�idle
        if (!Player.IsWallDetected())
            stateMachine.ChangeState(Player.idleState);

        if (xInput != 0 && Player.facingDir * xInput < 0)
            stateMachine.ChangeState(Player.idleState);

        // �����»��ٶ�
        if (yInput < 0)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y * Player.slideSpeed);

        // ����л�idle
        if (Player.IsGroundDetected())
            stateMachine.ChangeState(Player.idleState);
    }
}