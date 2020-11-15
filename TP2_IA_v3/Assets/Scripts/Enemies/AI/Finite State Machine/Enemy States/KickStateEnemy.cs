using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickStateEnemy<T>:FSMState<T>
{

    EnemyBoss _enemy;
    EnemyBossAnim _enemyAnimations;

    Player _player;
    Kick<Enemy> kickAtttack;
    public KickStateEnemy(EnemyBoss enemy, EnemyBossAnim enemyAnimations)
    {
        _enemy=enemy;
        _enemyAnimations=enemyAnimations;

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
