using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick<T> : Attack<T>
{
    Animator _animator;
    
    public Kick(T _character, T _target, Animator animator)
    {
        character=_character;
        animator=_animator;
    }

    // public override void DoAttack(T target)
    // {
    //      OnAttack?.Invoke();
    // }
}
