using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    
    FSMState<T> _currentState;

    public void SetInit(FSMState<T> init)
    {
        _currentState=init;
        _currentState.Awake();
    }

    public void OnUpdate()
    {
        if(_currentState!=null)
            _currentState.Execute();
    }

    public void Transition(T input)
    {
        FSMState<T> newState=_currentState.GetTransition(input);
        if(newState==null) return;
        _currentState.Sleep();
        _currentState=newState;
        _currentState.Awake();
    }

}
