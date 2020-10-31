using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AttackDel();
public abstract class Attack<T>
{
    // public T[] Combo;
    
    public T character;

    public abstract void AttackTarget(GameObject target);

    // public abstract void AttackDel(T target);
}
