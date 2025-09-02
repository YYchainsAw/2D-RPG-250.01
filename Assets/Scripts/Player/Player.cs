// Assets\Scripts\Player\Player.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������࣬������ҵ����ԡ�״̬��������
/// </summary>
public class Player : Entity
{
    [Header("��������")]
    public Vector2[] attackMovement; // ����ʱ��λ�Ʋ��� 
    public float counterAttackDuration; // ��������ʱ��

    public bool isBusy { get; private set; } // ����Ƿ���æµ״̬���繥���У�
    [Header("�ƶ�")]
    public float moveSpeed = 12f; // �ƶ��ٶ�
    public float jumpForce; // ��Ծ����

    [Header("���")]
    public float dashSpeed; // ����ٶ�
    public float dashDuration; // ��̳���ʱ��
    public float dashDir { get; private set; } // ��̷���

    [Header("��ǽ")]
    [SerializeField] public float slideSpeed; // ��ǽ�ٶ�

    #region States
    public PlayerStateMachine StateMachine { get; private set; } // ״̬��

    public PlayeridleState idleState { get; private set; } // ����״̬
    public PlayerMoveState moveState { get; private set; } // �ƶ�״̬
    public PlayerAirState airState { get; private set; } // ����״̬
    public PlayerJumpState jumpState { get; private set; } // ��Ծ״̬
    public PlayerDashState dashState { get; private set; } // ���״̬
    public PlayerWallSlideState wallSlide { get; private set; } // ��ǽ״̬
    public PlayerWallJumpState wallJump { get; private set; } // ǽ��״̬
    public PlayerPrimaryAttackState primaryAttack { get; private set; } // ������״̬
    public PlayerCounterAttackState counterAttack { get; private set; } // ����״̬
    #endregion

    /// <summary>
    /// ��ʼ��״̬���͸�״̬
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
    /// ����ʱ���ó�ʼ״̬
    /// </summary>
    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(idleState);
    }

    /// <summary>
    /// ÿ֡���£�����״̬���ͳ������
    /// </summary>
    protected override void Update()
    {
        base.Update();
        StateMachine.currentState.Update();
        CheckForDashInput();
    }

    /// <summary>
    /// æµЭ�̣��������ڼ����
    /// </summary>
    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    /// <summary>
    /// �����¼�����
    /// </summary>
    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();

    /// <summary>
    /// ���������
    /// </summary>
    public void CheckForDashInput()
    {
        // ��ǽ���Ҳ��ڵ���ʱ���ܳ��
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