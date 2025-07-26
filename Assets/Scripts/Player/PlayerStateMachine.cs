// Assets\Scripts\Player\PlayerStateMachine.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家状态机，负责状态切换
/// </summary>
public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState { get; private set; } // 当前状态

    /// <summary>
    /// 初始化状态机
    /// </summary>
    public void Initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    /// <summary>
    /// 切换到新状态
    /// </summary>
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}