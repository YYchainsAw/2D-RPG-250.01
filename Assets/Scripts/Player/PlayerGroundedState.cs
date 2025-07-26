// Assets\Scripts\Player\PlayerGroundedState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ڵ����ϵ�ͨ��״̬����
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

        // ��������
        if (Input.GetKeyDown(KeyCode.J))
            stateMachine.ChangeState(Player.primaryAttack);

        // ���µ����л�������
        if (!Player.IsGroundDetected())
            stateMachine.ChangeState(Player.airState);

        // ��Ծ����
        if (Input.GetKeyDown(KeyCode.K) && Player.IsGroundDetected())
            stateMachine.ChangeState(Player.jumpState);
    }
}