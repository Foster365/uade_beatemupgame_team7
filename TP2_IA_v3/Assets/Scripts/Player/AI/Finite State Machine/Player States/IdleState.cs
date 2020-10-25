using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : FSMState<T>
{
    FSM<T> _fsm;
    T _moveInput;
    T _jumpInput;
    public IdleState(FSM<T> fsm, T mI, T jI)
    {
        _fsm = fsm;
        _moveInput = mI;
        _jumpInput = jI;
    }
    public override void Execute()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        if (h != 0 || v != 0)
        {
            _fsm.Transition(_moveInput);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _fsm.Transition(_jumpInput);
        }
    }
    public override void Awake()
    {
        Debug.Log("IdleState");
    }
    public override void Sleep()
    {
        
    }
}
