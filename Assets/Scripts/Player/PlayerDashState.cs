using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��ҳ��״̬
/// </summary>
public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    /// <summary>
    /// ������״̬�����ó�̳���ʱ��
    /// </summary>
    public override void Enter()
    {
        base.Enter();

        Player.skill.clone.CreateClone(Player.transform); // ��������

        stateTimer = Player.dashDuration; // ���ó�̳���ʱ��
    }

    /// <summary>
    /// �˳����״̬��ֹͣˮƽ�ٶ�
    /// </summary>
    public override void Exit()
    {
        base.Exit();

        Player.SetVelocity(0, rb.velocity.y); // �˳�ʱֹͣˮƽ�ٶ�
    }

    /// <summary>
    /// ���״̬ÿ֡����
    /// </summary>
    public override void Update()
    {
        base.Update();

        // ��̹���������ڿ����Ҽ�⵽ǽ�壬�л�����ǽ״̬
        if (!Player.IsGroundDetected() && Player.IsWallDetected())
            stateMachine.ChangeState(Player.wallSlide);

        // �������ó���ٶ�
        Player.SetVelocity(Player.dashSpeed * Player.dashDir, 0);

        // ���ʱ��������л���idle
        if (stateTimer < 0)
            stateMachine.ChangeState(Player.idleState);
    }
}