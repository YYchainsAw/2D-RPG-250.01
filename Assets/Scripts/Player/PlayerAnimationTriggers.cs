// Assets\Scripts\Player\PlayerAnimationTriggers.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家动画事件触发器，供动画事件调用
/// </summary>
public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player Player => GetComponentInParent<Player>();

    /// <summary>
    /// 动画完成事件
    /// </summary>
    private void AnimationTrigger()
    {
        Player.AnimationTrigger();
    }
}