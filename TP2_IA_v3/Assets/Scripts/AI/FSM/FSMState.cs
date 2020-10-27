using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState<T>
{
    public virtual void Awake(){}
    public virtual void Execute(){}

    public virtual void Sleep(){}

    Dictionary<T, FSMState<T>> _FsmDictionary=new Dictionary<T, FSMState<T>> ();

    public void AddTransition(T input, FSMState<T> state)
    {
        if(!_FsmDictionary.ContainsKey(input))
            _FsmDictionary.Add(input, state);
    }

    public void RemoveTransition(T input)
    {
        if(_FsmDictionary.ContainsKey(input))
            _FsmDictionary.Remove(input);
    }

    public FSMState<T> GetTransition(T input)
    {
        if(_FsmDictionary.ContainsKey(input))
            return _FsmDictionary[input];
        return null;
    }
}
