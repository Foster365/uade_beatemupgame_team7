using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : FSMState<T>
{
    FSM<T> _fsm;
    T _moveInput;
    T _attackInput;
    PlayerAnimation _anim;
    public IdleState(FSM<T> fsm, PlayerAnimation anim, T mI, T aI)
    {
        _fsm = fsm;
        _moveInput = mI;
        _attackInput = aI;
        _anim = anim;
    }
    public override void Execute()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            _fsm.Transition(_moveInput);
        }
        else if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K))
        {
            
            _fsm.Transition(_attackInput);
        }
    }
    public override void Awake()
    {
        Debug.Log("IdleState");
        _anim.Walk(false);
    }
    public override void Sleep()
    {
        
    }
}
