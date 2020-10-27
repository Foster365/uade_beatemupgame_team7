using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy<T>:FSMState<T>
{
    Enemy _enemy;
    EnemyAnimations _enemyAnimations;
    public AttackStateEnemy(Enemy enemy, EnemyAnimations enemyAnimations)
    {
        _enemy=enemy;
        _enemyAnimations=enemyAnimations;
    }

    public override void Awake()
    {
        Debug.Log("Enemy AttackState Awake");
    }

    public override void Execute()
    {
        Debug.Log("Enemy AttackState Execute");
    }

    public override void Sleep()
    {
        Debug.Log("Enemy AttackState Sleep");
    }
}
