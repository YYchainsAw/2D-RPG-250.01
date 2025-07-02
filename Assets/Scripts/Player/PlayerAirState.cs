using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (Player.IsWallDetected())
            stateMachine.ChangeState(Player.wallSlide);

        if (Player.IsGroundDetected())
            stateMachine.ChangeState(Player.idleState);

        if (xInput != 0)
            Player.SetVelocity(Player.moveSpeed * .8f * xInput, rb.velocity.y);
    }
}
