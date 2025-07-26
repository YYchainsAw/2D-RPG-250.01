using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer; // ���ͼ�����룬���ڼ�����

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

    public virtual void AnimationFinishedTrigger() => stateMachine.currentState.AnimationFinishedTrigger(); // ������ɴ����������õ�ǰ״̬�Ķ�����ɷ���


    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 25, whatIsPlayer); // �������Ƿ���ڣ�ʹ�����߼��

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow; // ����Gizmos��ɫΪ��ɫ

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y)); // ���ƹ�����Χ����
    }
}