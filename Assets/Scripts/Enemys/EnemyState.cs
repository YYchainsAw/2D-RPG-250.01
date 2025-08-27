using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected EnemyStateMachine stateMachine; // 状态机引用
    protected Enemy enemyBase; // 敌人本体引用
    protected Rigidbody2D rb; // 刚体组件

    protected bool triggerCalled; // 动画事件触发标记
    private string animBoolName; // 动画参数名

    protected float stateTimer; // 状态计时器

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName; 
    }


    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }


   
    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animBoolName, true);
    }

    
 
    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);
    }

    // 动画事件触发

    public virtual void AnimationFinishedTrigger()
    {
        triggerCalled = true;
    }
}
