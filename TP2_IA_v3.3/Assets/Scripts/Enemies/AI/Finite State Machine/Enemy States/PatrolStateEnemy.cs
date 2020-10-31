using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolStateEnemy<T>:FSMState<T>
{
    Enemy _enemy;
    EnemyAnimations _enemyAnimations;
    public PatrolStateEnemy(Enemy enemy, EnemyAnimations enemyAnimations)
    {
        _enemy=enemy;
        _enemyAnimations=enemyAnimations;
    }
    
    public override void Awake()
    {
        Debug.Log("Enemy Idle State Awake");
    }

    public override void Execute()
    {
        Debug.Log("Enemy Idle State Execute");
        _enemy.GoToWaypoint();
        _enemyAnimations.MoveAnimation(true);
    }

    public override void Sleep()
    {
        Debug.Log("Enemy Idle State Sleep");
    }
}