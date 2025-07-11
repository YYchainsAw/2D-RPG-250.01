using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonAnimationTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy_Skeleton>();
    }


    // �������¼�����
    public void AnimationFinishTrigger()
    {
        enemy.AnimationFinishedTrigger();
    }

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
}
