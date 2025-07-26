using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    // 构造函数，初始化玩家空中状态
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // 进入空中状态时调用
    public override void Enter()
    {
        base.Enter();
    }

    // 退出空中状态时调用
    public override void Exit()
    {
        base.Exit();
    }

    // 每帧更新空中状态
    public override void Update()
    {
        base.Update();

        // 如果检测到墙壁，切换到墙壁滑动状态
        if (Player.IsWallDetected())
            stateMachine.ChangeState(Player.wallSlide);

        // 如果检测到地面，切换到空闲状态
        if (Player.IsGroundDetected())
            stateMachine.ChangeState(Player.idleState);

        // 如果有水平输入，设置玩家水平速度（空中移动速度为正常移动速度的80%）
        if (xInput != 0)
            Player.SetVelocity(Player.moveSpeed * .8f * xInput, rb.velocity.y);
    }
}