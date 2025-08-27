// Assets\Scripts\Player\PlayerAnimationTriggers.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家动画事件触发器，供动画事件调用
/// </summary>
public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    /// <summary>
    /// 动画完成事件
    /// </summary>
    public void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    /// <summary>
    /// 攻击事件
    /// </summary>
    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }
}