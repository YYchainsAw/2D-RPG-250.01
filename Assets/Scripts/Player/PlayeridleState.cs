// Assets\Scripts\Player\PlayeridleState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ҵ���״̬
/// </summary>
public class PlayeridleState : PlayerGroundedState
{
    public PlayeridleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // �������״̬ʱ�ٶȹ���
        Player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // �����������ǽ���л�
        if (xInput == Player.facingDir && Player.IsWallDetected())
            return;

        // ���������л����ƶ�״̬
        if (xInput != 0)
            stateMachine.ChangeState(Player.moveState);
    }
}