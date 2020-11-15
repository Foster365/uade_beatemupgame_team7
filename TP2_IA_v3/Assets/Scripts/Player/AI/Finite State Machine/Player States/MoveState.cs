using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState<T> : FSMState<T>
{
    //Model: Comportamientos
    //View: Animaciones
    //Controller: Cerebro
    IMove _entity;
    T _attackInput;
    T _idleInput;
    PlayerAnimation _anim;
    FSM<T> _fsm;

    public MoveState(IMove e, FSM<T> fsm,PlayerAnimation anim, T aI, T iI)
    {
        _fsm = fsm;
        _attackInput = aI;
        _idleInput = iI;
        _entity = e;
        _anim = anim;
    }

    public override void Awake()
    {
       // Debug.Log("MoveState");
        _anim.Walk(true);

    }

    public override void Execute()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        _entity.Move(dir);
        if (h == 0 && v == 0)
        {
            //Realizar una transicion
            _fsm.Transition(_idleInput);
        }
        if (Input.GetKey(KeyCode.K)|| Input.GetKey(KeyCode.J))
        {
            _fsm.Transition(_attackInput);
        }
    }
}
