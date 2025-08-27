// Assets\Entity.cs
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/// <summary>
/// 实体基类，玩家和敌人都继承自此类，包含通用的移动、碰撞、翻转等功能
/// </summary>
public class Entity : MonoBehaviour
{
    [Header("Knockback info")]
    [SerializeField] protected Vector2 knockbackDirection; // 击退力
    [SerializeField] protected float knockbackDuration; // 击退力大小
    protected bool isKnocked; // 是否正在被击退

    [Header("碰撞")]
    public Transform attackCheck; // 攻击检测点
    public float attackCheckRadius; // 攻击检测半径
    [SerializeField] protected Transform groundCheck; // 地面检测点
    [SerializeField] protected float groundCheckDistance; // 地面检测距离
    [SerializeField] protected Transform wallCheck; // 墙体检测点
    [SerializeField] protected float wallCheckDistance; // 墙体检测距离
    [SerializeField] protected LayerMask whatIsGround; // 地面Layer

    public int facingDir { get; private set; } = 1; // 面朝方向，1为右，-1为左
    protected bool facingRight = true; // 是否面朝右

    #region Components
    public Animator anim { get; private set; } // 动画组件
    public Rigidbody2D rb { get; private set; } // 刚体组件
    public EntityFX fx { get; private set; } // 特效组件
    #endregion

    /// <summary>
    /// 初始化组件（可被子类重写）
    /// </summary>
    protected virtual void Awake()
    {

    }

    /// <summary>
    /// 获取动画和刚体组件
    /// </summary>
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<EntityFX>();
    }

    /// <summary>
    /// 每帧更新（可被子类重写）
    /// </summary>
    protected virtual void Update()
    {

    }

    /// <summary>
    /// 受伤/被攻击接口，子类可重写
    /// </summary>
    public virtual void Damage()
    {
        fx.StartCoroutine("FlashFX"); // 播放闪烁特效

        StartCoroutine(HitKnockback()); // 开始击退协程
    }

    protected virtual IEnumerator HitKnockback()
    {
        isKnocked = true;
        
        rb.velocity = new Vector2(knockbackDirection.x * -facingDir, knockbackDirection.y); 

        yield return new WaitForSeconds(knockbackDuration); 

        isKnocked = false; // 重置击退状态
    }

    #region 速度
    /// <summary>
    /// 速度归零
    /// </summary>
    public void SetZeroVelocity() 
    {
        if (isKnocked) return; // 如果正在被击退，则不允许设置速度

        rb.velocity = new Vector2(0, 0);
    } 

    /// <summary>
    /// 设置速度并自动翻转
    /// </summary>
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnocked) return; // 如果正在被击退，则不允许设置速度

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region 碰撞
    /// <summary>
    /// 检测是否在地面上
    /// </summary>
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    /// <summary>
    /// 检测是否碰到墙体
    /// </summary>
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    /// <summary>
    /// 在Scene视图中绘制辅助线和攻击范围
    /// </summary>
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region 翻转
    /// <summary>
    /// 翻转角色朝向
    /// </summary>
    public virtual void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    /// <summary>
    /// 根据x速度自动翻转
    /// </summary>
    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion
}