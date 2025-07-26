// Assets\Scripts\Player\PlayerWallJumpState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ǽ��״̬
/// </summary>
public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = .4f; // ǽ������ʱ��
        Player.SetVelocity(5 * -Player.facingDir, Player.jumpForce); // ǽ�����ٶ�
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // ǽ��ʱ������л�������
        if (stateTimer < 0)
            stateMachine.ChangeState(Player.airState);

        // ����л���idle
        if (Player.IsGroundDetected())
            stateMachine.ChangeState(Player.idleState);
    }
}