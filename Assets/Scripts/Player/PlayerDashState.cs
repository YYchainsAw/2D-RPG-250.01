using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = Player.dashDuration;
    }

    public override void Exit()
    {
        base.Exit();

        Player.SetVelocity(0, rb.velocity.y);
    }

    public override void Update()
    {
        base.Update();

        if (!Player.IsGroundDetected() && Player.IsWallDetected()) 
            stateMachine.ChangeState(Player.wallSlide);


        Player.SetVelocity(Player.dashSpeed * Player.dashDir, 0);

        if (stateTimer < 0) 
            stateMachine.ChangeState(Player.idleState);
    }
}
