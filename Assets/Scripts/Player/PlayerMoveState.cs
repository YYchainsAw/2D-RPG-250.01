// Assets\Scripts\Player\PlayerMoveState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ƶ�״̬
/// </summary>
public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        // �����ƶ��ٶ�
        Player.SetVelocity(xInput * Player.moveSpeed, rb.velocity.y);

        // û������ʱ�л���idle
        if (xInput == 0)
            stateMachine.ChangeState(Player.idleState);
    }
}