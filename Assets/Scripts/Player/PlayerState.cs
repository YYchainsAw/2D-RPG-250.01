// Assets\Scripts\Player\PlayerState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������״̬�Ļ���
/// </summary>
public class PlayerState
{
    protected PlayerStateMachine stateMachine; // ״̬������
    protected Player Player; // �������
    protected Rigidbody2D rb; // ��������

    protected float xInput; // ˮƽ����
    protected float yInput; // ��ֱ����
    private string animBoolName; // ����������

    protected float stateTimer; // ״̬��ʱ��
    protected bool triggerCalled; // �����¼��������

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
        this.Player = _player;
    }

    /// <summary>
    /// ����״̬ʱ����
    /// </summary>
    public virtual void Enter()
    {
        Player.anim.SetBool(animBoolName, true);
        rb = Player.rb;
        triggerCalled = false;
    }

    /// <summary>
    /// ÿ֡����
    /// </summary>
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Player.anim.SetFloat("yVelocity", rb.velocity.y);
    }

    /// <summary>
    /// �˳�״̬ʱ����
    /// </summary>
    public virtual void Exit()
    {
        Player.anim.SetBool(animBoolName, false);
    }

    /// <summary>
    /// �����¼�����
    /// </summary>
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}