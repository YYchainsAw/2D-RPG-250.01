using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    // ���캯������ʼ�������Ծ״̬
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // ������Ծ״̬ʱ����
    public override void Enter()
    {
        base.Enter();

        // ������ҵĴ�ֱ�ٶ�Ϊ��Ծ��������ˮƽ�ٶȲ���
        rb.velocity = new Vector2(rb.velocity.x, Player.jumpForce);
    }

    // �˳���Ծ״̬ʱ����
    public override void Exit()
    {
        base.Exit();
    }

    // ÿ֡������Ծ״̬
    public override void Update()
    {
        base.Update();

        // �����Ҵ�ֱ�ٶ�С��0����ʼ���䣩���л�������״̬
        if (rb.velocity.y < 0)
            stateMachine.ChangeState(Player.airState);
    }
}