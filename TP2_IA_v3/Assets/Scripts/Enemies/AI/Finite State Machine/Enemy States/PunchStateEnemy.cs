using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchStateEnemy<T>:FSMState<T>
{
    Enemy _enemy;
    EnemyAnimations _enemyAnimations;

    Player _player;
    Punch<Enemy> punchEnemy;
    public PunchStateEnemy(Enemy enemy, EnemyAnimations enemyAnimations)
    {
        _enemy=enemy;
        _enemyAnimations=enemyAnimations;

    }

    public override void Awake()
    {
        Debug.Log("Enemy KickState Awake");
        punchEnemy=new Punch<Enemy>(_enemy);
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
