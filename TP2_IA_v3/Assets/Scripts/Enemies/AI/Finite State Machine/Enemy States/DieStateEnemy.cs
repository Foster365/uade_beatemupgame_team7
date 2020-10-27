using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieStateEnemy<T>:FSMState<T>
{
    Enemy _enemy;
    EnemyAnimations _enemyAnimations;
    public DieStateEnemy(Enemy enemy, EnemyAnimations enemyAnimations)
    {
        _enemy=enemy;
        _enemyAnimations=enemyAnimations;
    }

    public override void Awake()
    {
        Debug.Log("Enemy DieState Awake");
    }
    public override void Execute()
    {
        Debug.Log("Enemy DieState Execute");
    }
    public override void Sleep()
    {
        Debug.Log("Enemy DieState Sleep");
    }
}
