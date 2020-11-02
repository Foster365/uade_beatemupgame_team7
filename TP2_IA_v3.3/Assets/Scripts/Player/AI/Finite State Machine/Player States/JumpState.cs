using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState<T> : FSMState<T>
{
    FSM<T> _fsm;
    T _idleInput;
    Rigidbody _rb;
    Player _player;
    public JumpState(FSM<T> fsm, T iI, Rigidbody rb, Player player)
    {
        _idleInput = iI;
        _fsm = fsm;
        _rb = rb;
        _player = player;
    }
    public override void Awake()
    {
        _player.Jump();
        Debug.Log("JumpState");
    }
    public override void Execute()
    {
        if (_rb.velocity.y == 0)
        {
            _fsm.Transition(_idleInput);
        }
    }
}
