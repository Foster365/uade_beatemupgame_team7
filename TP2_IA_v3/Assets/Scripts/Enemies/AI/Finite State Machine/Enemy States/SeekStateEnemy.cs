using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekStateEnemy<T>:FSMState<T>
{
    Enemy _enemy;
    EnemyAnimations _enemyAnimations;
    public SeekStateEnemy(Enemy enemy, EnemyAnimations enemyAnimations)
    {
        _enemy=enemy;
        _enemyAnimations=enemyAnimations;
    }

    public override void Awake()
    {
        Debug.Log("Enemy SeekState Awake");
    }

    public override void Execute()
    {
        Debug.Log("Enemy SeekState Execute");
    }

    public override void Sleep()
    {
        Debug.Log("Enemy SeekState Sleep");
    }
}
