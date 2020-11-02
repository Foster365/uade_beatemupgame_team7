using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick<T> : Attack<T>
{
    Animator _animator;
    
    public Kick(T _character)
    {
        character=_character;
    }
    public override void AttackTarget(GameObject target)
    {

    }
}
