// Assets\Scripts\Player\PlayerAnimationTriggers.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ҷ����¼����������������¼�����
/// </summary>
public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player Player => GetComponentInParent<Player>();

    /// <summary>
    /// ��������¼�
    /// </summary>
    private void AnimationTrigger()
    {
        Player.AnimationTrigger();
    }
}