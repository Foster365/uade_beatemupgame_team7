using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateEnemy<T> : FSMState<T>
{

    EnemyBoss _enemyBoss;
    EnemyBossAnim _enemyBossAnimations;
    Player _target;

    FSM<T> _fsm;
    T _idleStateEnemy;
    T _attackStateEnemy;

    public BlockStateEnemy(EnemyBoss enemyBoss, EnemyBossAnim enemyBossAnimations, Player target, FSM<T> fsm,
    T idleStateEnemy, T attackStateEnemy)
    {
        _enemyBoss = enemyBoss;
        _enemyBossAnimations = enemyBossAnimations;
        _target = target;

        _fsm = fsm;
        _idleStateEnemy = idleStateEnemy;
        _attackStateEnemy = attackStateEnemy;

    }

    public override void Awake()
    {
        Debug.Log("Enemy BlockState Awake");

    }

    public override void Execute()
    {
        Debug.Log("Enemy BlockState Execute");

        if (Vector3.Distance(_enemyBoss.transform.position, _target.transform.position) >= _enemyBoss.attackRange)
            _fsm.Transition(_idleStateEnemy);
        else
            _fsm.Transition(_attackStateEnemy);


    }

    public override void Sleep()
    {
        Debug.Log("Enemy BlockState Sleep");
    }
}
