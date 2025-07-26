// Assets\Scripts\Player\PlayerGroundedState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家在地面上的通用状态基类
/// </summary>
public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        // 攻击输入
        if (Input.GetKeyDown(KeyCode.J))
            stateMachine.ChangeState(Player.primaryAttack);

        // 掉下地面切换到空中
        if (!Player.IsGroundDetected())
            stateMachine.ChangeState(Player.airState);

        // 跳跃输入
        if (Input.GetKeyDown(KeyCode.K) && Player.IsGroundDetected())
            stateMachine.ChangeState(Player.jumpState);
    }
}