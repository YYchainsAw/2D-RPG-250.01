// Assets\Scripts\Player\PlayerAnimationTriggers.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ҷ����¼����������������¼�����
/// </summary>
public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    /// <summary>
    /// ��������¼�
    /// </summary>
    public void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    /// <summary>
    /// �����¼�
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