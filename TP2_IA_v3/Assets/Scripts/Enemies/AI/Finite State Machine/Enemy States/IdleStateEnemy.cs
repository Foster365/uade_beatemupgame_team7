using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateEnemy<T>:FSMState<T>
{

    public EnemyAnimations _enemyAnimations;

    public IdleStateEnemy(EnemyAnimations enemyAnimations)
    {
        _enemyAnimations=enemyAnimations;
    }

    public override void Awake()
    {
        Debug.Log("Enemy Idle State Awake");
    }

    public override void Execute()
    {
        Debug.Log("Enemy Idle State Execute");
    }

    public override void Sleep()
    {
        Debug.Log("Enemy Idle State Sleep");
    }
}