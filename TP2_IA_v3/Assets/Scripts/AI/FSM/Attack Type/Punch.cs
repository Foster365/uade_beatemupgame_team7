using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch <T> : Attack<T>
{
    Animator _animator;
    
    public Punch(T _character, T _target, Animator animator)
    {
        character=_character;
        animator=_animator;
    }

}
