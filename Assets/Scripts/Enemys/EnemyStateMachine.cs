using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ����״̬��������״̬�л�

public class EnemyStateMachine
{
    public EnemyState currentState { get; private set; } // ��ǰ״̬

   
    // ��ʼ��״̬��

    public void Initialize(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }


    // �л�����״̬
    public void ChangeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}