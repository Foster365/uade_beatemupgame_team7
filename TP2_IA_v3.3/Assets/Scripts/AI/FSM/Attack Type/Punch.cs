using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch<T> : Attack<T>
{
    Animator _animator;
    
    public Punch(T _character)
    {
        character=_character;
    }

    public override void AttackTarget(GameObject target)
    {
        
    }

}
