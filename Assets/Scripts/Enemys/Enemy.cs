using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer; // ���ͼ�����룬���ڼ�����

    [Header("ѣ��")]
    public float stunDuration;   // ѣ�γ���ʱ��
    public Vector2 stunDirection; // ѣ��ʱ�Ļ��˷���
    protected bool canBeStunned; // �Ƿ���Ա�ѣ��
    [SerializeField] protected GameObject counterImage;


    [Header("�ƶ�")]
    public float moveSpeed; // �����ƶ��ٶ�
    public float idleTime; // ���˿���ʱ��
    public float battleTime; // ����ս������ʱ��

    [Header("����")]
    public float attackDistance; // ���˹�������
    public float attackCooldown; // ������ȴʱ��
    [HideInInspector] public float lastTimeAttack; // �ϴι�����ʱ��

    public EnemyStateMachine stateMachine { get; private set; } // ����״̬��

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine(); // ��ʼ������״̬��
    }


    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update(); // ���µ�ǰ״̬����״̬
    }

    public virtual void OpenCounterAttackWindow() // �򿪷�������ͼ��
    {
        canBeStunned = true; // ���ÿ��Ա�ѣ��
        counterImage.SetActive(true); // �����ͼ��
    }

    public virtual void CloseCounterAttackWindow() // �رշ�������ͼ��
    {
        canBeStunned = false; // ���ò��ܱ�ѣ��
        counterImage.SetActive(false); // ���÷���ͼ��
    }

    public virtual bool CanBeStunned()// ����Ƿ���Ա�ѣ��
    {
        if (canBeStunned) // ������Ա�ѣ��
        {
            CloseCounterAttackWindow(); // �رշ�������ͼ��
            return true; // ����true
        }

        return false; // ���򷵻�false
    }

    public virtual void AnimationFinishedTrigger() => stateMachine.currentState.AnimationFinishedTrigger(); // ������ɴ����������õ�ǰ״̬�Ķ�����ɷ���


    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 25, whatIsPlayer); // �������Ƿ���ڣ�ʹ�����߼��

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow; // ����Gizmos��ɫΪ��ɫ

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y)); // ���ƹ�����Χ����
    }
}