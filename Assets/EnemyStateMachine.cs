using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 敌人状态机，负责状态切换

public class EnemyStateMachine
{
    public EnemyState currentState { get; private set; } // 当前状态

   
    // 初始化状态机

    public void Initialize(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }


    // 切换到新状态
    public void ChangeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}