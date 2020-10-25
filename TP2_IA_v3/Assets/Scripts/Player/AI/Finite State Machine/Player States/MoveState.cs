using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState<T> : FSMState<T>
{
    //Model: Comportamientos
    //View: Animaciones
    //Controller: Cerebro
    IMove _entity;
    T _jumpInput;
    T _idleInput;
    FSM<T> _fsm;
    public MoveState(IMove e, FSM<T> fsm, T jI, T iI)
    {
        _fsm = fsm;
        _jumpInput = jI;
        _idleInput = iI;
        _entity = e;
    }

    public override void Awake()
    {
        Debug.Log("MoveState");
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
        if (Input.GetKey(KeyCode.Space))
        {
            _fsm.Transition(_jumpInput);
        }
    }
}
