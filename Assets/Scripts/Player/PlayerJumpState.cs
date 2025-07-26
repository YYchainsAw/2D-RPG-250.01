using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    // 构造函数，初始化玩家跳跃状态
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // 进入跳跃状态时调用
    public override void Enter()
    {
        base.Enter();

        // 设置玩家的垂直速度为跳跃力，保持水平速度不变
        rb.velocity = new Vector2(rb.velocity.x, Player.jumpForce);
    }

    // 退出跳跃状态时调用
    public override void Exit()
    {
        base.Exit();
    }

    // 每帧更新跳跃状态
    public override void Update()
    {
        base.Update();

        // 如果玩家垂直速度小于0（开始下落），切换到空中状态
        if (rb.velocity.y < 0)
            stateMachine.ChangeState(Player.airState);
    }
}