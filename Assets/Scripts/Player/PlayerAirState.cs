using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    // ���캯������ʼ����ҿ���״̬
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // �������״̬ʱ����
    public override void Enter()
    {
        base.Enter();
    }

    // �˳�����״̬ʱ����
    public override void Exit()
    {
        base.Exit();
    }

    // ÿ֡���¿���״̬
    public override void Update()
    {
        base.Update();

        // �����⵽ǽ�ڣ��л���ǽ�ڻ���״̬
        if (Player.IsWallDetected())
            stateMachine.ChangeState(Player.wallSlide);

        // �����⵽���棬�л�������״̬
        if (Player.IsGroundDetected())
            stateMachine.ChangeState(Player.idleState);

        // �����ˮƽ���룬�������ˮƽ�ٶȣ������ƶ��ٶ�Ϊ�����ƶ��ٶȵ�80%��
        if (xInput != 0)
            Player.SetVelocity(Player.moveSpeed * .8f * xInput, rb.velocity.y);
    }
}