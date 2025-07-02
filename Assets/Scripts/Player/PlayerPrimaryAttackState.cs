using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{

    private int comboCounter;

    private float lastTimeAttacked;
    private float comboWindow = 1;
    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            comboCounter = 0;

        Player.anim.SetInteger("ComboCounter", comboCounter);

        #region Ñ¡Ôñ¹¥»÷³¯Ïò

        float attackDir = Player.facingDir;

        if (xInput != 0)
            attackDir = xInput;

        #endregion

        Player.SetVelocity(Player.attackMovement[comboCounter].x * attackDir, Player.attackMovement[comboCounter].y);

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        Player.StartCoroutine("BusyFor", .1f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            Player.ZeroVelocity();

        if (triggerCalled) 
            stateMachine.ChangeState(Player.idleState);
    }
}
