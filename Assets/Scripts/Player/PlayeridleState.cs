// Assets\Scripts\Player\PlayeridleState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家待机状态
/// </summary>
public class PlayeridleState : PlayerGroundedState
{
    public PlayeridleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // 进入待机状态时速度归零
        Player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // 如果朝向方向有墙则不切换
        if (xInput == Player.facingDir && Player.IsWallDetected())
            return;

        // 有输入则切换到移动状态
        if (xInput != 0)
            stateMachine.ChangeState(Player.moveState);
    }
}