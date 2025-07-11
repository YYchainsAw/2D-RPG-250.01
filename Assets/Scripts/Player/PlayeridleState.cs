using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeridleState : PlayerGroundedState
{
    public PlayeridleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput == Player.facingDir && Player.IsWallDetected()) 
            return;

        if (xInput != 0) 
            stateMachine.ChangeState(Player.moveState);
    }
}
