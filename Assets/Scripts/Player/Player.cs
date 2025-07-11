using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("¹¥»÷ÏêÇé")]
    public Vector2[] attackMovement;
   

    public bool isBusy {  get; private set; }
    [Header("ÒÆ¶¯")]
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("³å´Ì")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTime;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }

    [Header("»¬Ç½")]
    [SerializeField] public float slideSpeed;

    #region States
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayeridleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    #endregion

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
    }

    protected override void Start()
    {     
        base.Start();

        StateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        StateMachine.currentState.Update();

        CheckForDashInput();       
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true; 

        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }

    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();
    public void CheckForDashInput()
    {
        if (IsWallDetected() && !IsGroundDetected()) 
            return;

        dashUsageTime -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L) && dashUsageTime < 0)
        {
            dashUsageTime = dashCooldown;

            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;

            StateMachine.ChangeState(dashState);
        }
    }
    
}
