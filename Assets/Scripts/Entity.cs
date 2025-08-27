// Assets\Entity.cs
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/// <summary>
/// ʵ����࣬��Һ͵��˶��̳��Դ��࣬����ͨ�õ��ƶ�����ײ����ת�ȹ���
/// </summary>
public class Entity : MonoBehaviour
{
    [Header("Knockback info")]
    [SerializeField] protected Vector2 knockbackDirection; // ������
    [SerializeField] protected float knockbackDuration; // ��������С
    protected bool isKnocked; // �Ƿ����ڱ�����

    [Header("��ײ")]
    public Transform attackCheck; // ��������
    public float attackCheckRadius; // �������뾶
    [SerializeField] protected Transform groundCheck; // �������
    [SerializeField] protected float groundCheckDistance; // ���������
    [SerializeField] protected Transform wallCheck; // ǽ�����
    [SerializeField] protected float wallCheckDistance; // ǽ�������
    [SerializeField] protected LayerMask whatIsGround; // ����Layer

    public int facingDir { get; private set; } = 1; // �泯����1Ϊ�ң�-1Ϊ��
    protected bool facingRight = true; // �Ƿ��泯��

    #region Components
    public Animator anim { get; private set; } // �������
    public Rigidbody2D rb { get; private set; } // �������
    public EntityFX fx { get; private set; } // ��Ч���
    #endregion

    /// <summary>
    /// ��ʼ��������ɱ�������д��
    /// </summary>
    protected virtual void Awake()
    {

    }

    /// <summary>
    /// ��ȡ�����͸������
    /// </summary>
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<EntityFX>();
    }

    /// <summary>
    /// ÿ֡���£��ɱ�������д��
    /// </summary>
    protected virtual void Update()
    {

    }

    /// <summary>
    /// ����/�������ӿڣ��������д
    /// </summary>
    public virtual void Damage()
    {
        fx.StartCoroutine("FlashFX"); // ������˸��Ч

        StartCoroutine(HitKnockback()); // ��ʼ����Э��
    }

    protected virtual IEnumerator HitKnockback()
    {
        isKnocked = true;
        
        rb.velocity = new Vector2(knockbackDirection.x * -facingDir, knockbackDirection.y); 

        yield return new WaitForSeconds(knockbackDuration); 

        isKnocked = false; // ���û���״̬
    }

    #region �ٶ�
    /// <summary>
    /// �ٶȹ���
    /// </summary>
    public void SetZeroVelocity() 
    {
        if (isKnocked) return; // ������ڱ����ˣ������������ٶ�

        rb.velocity = new Vector2(0, 0);
    } 

    /// <summary>
    /// �����ٶȲ��Զ���ת
    /// </summary>
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnocked) return; // ������ڱ����ˣ������������ٶ�

        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }
    #endregion

    #region ��ײ
    /// <summary>
    /// ����Ƿ��ڵ�����
    /// </summary>
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    /// <summary>
    /// ����Ƿ�����ǽ��
    /// </summary>
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);

    /// <summary>
    /// ��Scene��ͼ�л��Ƹ����ߺ͹�����Χ
    /// </summary>
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    #endregion

    #region ��ת
    /// <summary>
    /// ��ת��ɫ����
    /// </summary>
    public virtual void Flip()
    {
        facingDir *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    /// <summary>
    /// ����x�ٶ��Զ���ת
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