// Assets\Scripts\Player\PlayerMoveState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家移动状态
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

        // 设置移动速度
        Player.SetVelocity(xInput * Player.moveSpeed, rb.velocity.y);

        // 没有输入时切换到idle
        if (xInput == 0)
            stateMachine.ChangeState(Player.idleState);
    }
}