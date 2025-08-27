using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 骷髅动画事件触发器，供动画事件调用

public class Enemy_SkeletonAnimationTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy_Skeleton>();
    }

    // 动画完成事件
    public void AnimationFinishedTrigger()
    {
        enemy.AnimationFinishedTrigger();
    }

    // 攻击事件
    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Player>().Damage();
            }
        }
    }

    private void OpenCounterWindow() => enemy.OpenCounterAttackWindow(); // 打开反击窗口
    private void CloseCounterWindow() => enemy.CloseCounterAttackWindow(); // 关闭反击窗口
}
