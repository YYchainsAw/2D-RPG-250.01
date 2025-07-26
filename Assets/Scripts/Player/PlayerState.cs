// Assets\Scripts\Player\PlayerState.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家所有状态的基类
/// </summary>
public class PlayerState
{
    protected PlayerStateMachine stateMachine; // 状态机引用
    protected Player Player; // 玩家引用
    protected Rigidbody2D rb; // 刚体引用

    protected float xInput; // 水平输入
    protected float yInput; // 垂直输入
    private string animBoolName; // 动画参数名

    protected float stateTimer; // 状态计时器
    protected bool triggerCalled; // 动画事件触发标记

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
        this.Player = _player;
    }

    /// <summary>
    /// 进入状态时调用
    /// </summary>
    public virtual void Enter()
    {
        Player.anim.SetBool(animBoolName, true);
        rb = Player.rb;
        triggerCalled = false;
    }

    /// <summary>
    /// 每帧更新
    /// </summary>
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        Player.anim.SetFloat("yVelocity", rb.velocity.y);
    }

    /// <summary>
    /// 退出状态时调用
    /// </summary>
    public virtual void Exit()
    {
        Player.anim.SetBool(animBoolName, false);
    }

    /// <summary>
    /// 动画事件触发
    /// </summary>
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}