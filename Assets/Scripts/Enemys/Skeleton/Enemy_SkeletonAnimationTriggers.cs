using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���ö����¼����������������¼�����

public class Enemy_SkeletonAnimationTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy_Skeleton>();
    }

    // ��������¼�
    public void AnimationFinishedTrigger()
    {
        enemy.AnimationFinishedTrigger();
    }

    // �����¼�
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

    private void OpenCounterWindow() => enemy.OpenCounterAttackWindow(); // �򿪷�������
    private void CloseCounterWindow() => enemy.CloseCounterAttackWindow(); // �رշ�������
}
