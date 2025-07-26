// Assets\Scripts\Player\PlayerStateMachine.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���״̬��������״̬�л�
/// </summary>
public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currentState { get; private set; } // ��ǰ״̬

    /// <summary>
    /// ��ʼ��״̬��
    /// </summary>
    public void Initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    /// <summary>
    /// �л�����״̬
    /// </summary>
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}