using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : FSMState<T>
{
    FSM<T> _fsm;
    T _moveInput;
    T _punchAttackInput;
    T _kickAttackInput;
    PlayerAnimation _anim;

    public IdleState(FSM<T> fsm, PlayerAnimation anim, T mI, T pI, T kI)
    {
        _fsm = fsm;
        _moveInput = mI;
        _punchAttackInput = pI;
        _kickAttackInput = kI;
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
        else if (Input.GetKey(KeyCode.J)) // Lleva a Punch State
        {
            
            _fsm.Transition(_punchAttackInput);
        }
        else if (Input.GetKey(KeyCode.K)) // Lleva a Kick State
        {

            _fsm.Transition(_kickAttackInput);
        }
    }
    public override void Awake()
    {
       // Debug.Log("IdleState");
        _anim.Walk(false);
    }
    public override void Sleep()
    {
        
    }
}
