using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateEnemy<T> : FSMState<T>
{

    Enemy _enemy;
    EnemyAnimations _enemyAnimations;

    Player _player;
    public BlockStateEnemy(Enemy enemy, EnemyAnimations enemyAnimations)
    {
        _enemy = enemy;
        _enemyAnimations = enemyAnimations;

    }

    public override void Awake()
    {
        Debug.Log("Enemy KickState Awake");

    }

    public override void Execute()
    {
        Debug.Log("Enemy KickState Execute");

    }

    public override void Sleep()
    {
        Debug.Log("Enemy KickState Sleep");
    }
}
