// Assets\Scripts\Player\Player.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家主类，管理玩家的属性、状态机和输入
/// </summary>
public class Player : Entity
{
    [Header("攻击详情")]
    public Vector2[] attackMovement; // 攻击时的位移参数 
    public float counterAttackDuration; // 反击持续时间

    public bool isBusy { get; private set; } // 玩家是否处于忙碌状态（如攻击中）
    [Header("移动")]
    public float moveSpeed = 12f; // 移动速度
    public float jumpForce; // 跳跃力度

    [Header("冲刺")]
    public float dashSpeed; // 冲刺速度
    public float dashDuration; // 冲刺持续时间
    public float dashDir { get; private set; } // 冲刺方向

    [Header("滑墙")]
    [SerializeField] public float slideSpeed; // 滑墙速度

    #region States
    public PlayerStateMachine StateMachine { get; private set; } // 状态机

    public PlayeridleState idleState { get; private set; } // 待机状态
    public PlayerMoveState moveState { get; private set; } // 移动状态
    public PlayerAirState airState { get; private set; } // 空中状态
    public PlayerJumpState jumpState { get; private set; } // 跳跃状态
    public PlayerDashState dashState { get; private set; } // 冲刺状态
    public PlayerWallSlideState wallSlide { get; private set; } // 滑墙状态
    public PlayerWallJumpState wallJump { get; private set; } // 墙跳状态
    public PlayerPrimaryAttackState primaryAttack { get; private set; } // 主攻击状态
    public PlayerCounterAttackState counterAttack { get; private set; } // 反击状态
    #endregion

    /// <summary>
    /// 初始化状态机和各状态
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        StateMachine = new PlayerStateMachine();

        idleState = new PlayeridleState(this, StateMachine, "Idle");
        moveState = new PlayerMoveState(this, StateMachine, "Move");
        jumpState = new PlayerJumpState(this, StateMachine, "Jump");
        airState = new PlayerAirState(this, StateMachine, "Jump");
        dashState = new PlayerDashState(this, StateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, StateMachine, "WallSlide");
        wallJump = new PlayerWallJumpState(this, StateMachine, "WallJump");
        primaryAttack = new PlayerPrimaryAttackState(this, StateMachine, "Attack");
        counterAttack = new PlayerCounterAttackState(this, StateMachine, "CounterAttack");
    }

    /// <summary>
    /// 启动时设置初始状态
    /// </summary>
    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(idleState);
    }

    /// <summary>
    /// 每帧更新，驱动状态机和冲刺输入
    /// </summary>
    protected override void Update()
    {
        base.Update();
        StateMachine.currentState.Update();
        CheckForDashInput();
    }

    /// <summary>
    /// 忙碌协程，攻击等期间调用
    /// </summary>
    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    /// <summary>
    /// 动画事件触发
    /// </summary>
    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();

    /// <summary>
    /// 检查冲刺输入
    /// </summary>
    public void CheckForDashInput()
    {
        // 在墙上且不在地面时不能冲刺
        if (IsWallDetected() && !IsGroundDetected())
            return;

      

        if (Input.GetKeyDown(KeyCode.L) && SkillManager.instance.dash.CanUseSkill())
        {
            
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = facingDir;
            StateMachine.ChangeState(dashState);
        }
    }
}