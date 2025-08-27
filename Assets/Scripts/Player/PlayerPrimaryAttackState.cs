// Assets\Scripts\Player\PlayerPrimaryAttackState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������״̬��������
/// </summary>
public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter; // ��������
    private float lastTimeAttacked; // �ϴι���ʱ��
    private float comboWindow = 1; // ��������ʱ��

    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        xInput = 0; // ����ˮƽ����

        // ������������ʱ������
        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;

        Player.anim.SetInteger("ComboCounter", comboCounter);

        // ���㹥������
        float attackDir = Player.facingDir;
        if (xInput != 0)
            attackDir = xInput;

        // ���ù���ʱ��λ��
        Player.SetVelocity(Player.attackMovement[comboCounter].x * attackDir, Player.attackMovement[comboCounter].y);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        // ���������æµ
        Player.StartCoroutine("BusyFor", .1f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        // �������ٶȹ���
        if (stateTimer < 0)
            Player.SetZeroVelocity();

        // �����¼��������л���idle
        if (triggerCalled)
            stateMachine.ChangeState(Player.idleState);
    }
}