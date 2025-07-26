using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer; // 玩家图层掩码，用于检测玩家

    [Header("移动")]
    public float moveSpeed; // 敌人移动速度
    public float idleTime; // 敌人空闲时间
    public float battleTime; // 敌人战斗持续时间

    [Header("攻击")]
    public float attackDistance; // 敌人攻击距离
    public float attackCooldown; // 攻击冷却时间
    [HideInInspector] public float lastTimeAttack; // 上次攻击的时间

    public EnemyStateMachine stateMachine { get; private set; } // 敌人状态机

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine(); // 初始化敌人状态机
    }


    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update(); // 更新当前状态机的状态
    }

    public virtual void AnimationFinishedTrigger() => stateMachine.currentState.AnimationFinishedTrigger(); // 动画完成触发器，调用当前状态的动画完成方法


    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 25, whatIsPlayer); // 检测玩家是否存在，使用射线检测

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.yellow; // 设置Gizmos颜色为黄色

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y)); // 绘制攻击范围的线
    }
}