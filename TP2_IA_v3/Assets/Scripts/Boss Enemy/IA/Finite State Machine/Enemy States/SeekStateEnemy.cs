using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekStateEnemy<T>:FSMState<T>
{
    EnemyBoss _enemyBoss;
    EnemyBossAnim _enemyBossAnimations;
    Player _target;

    FSM<T> _fsm;
    T _idleStateEnemy;
    T _attackStateEnemy;

    public SeekStateEnemy(EnemyBoss enemyBoss, EnemyBossAnim enemyBossAnimations, Player target, FSM<T> fsm, T idleStateEnemy, T attackStateEnemy)
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
        Debug.Log("Enemy SeekState Awake");
    }

    public override void Execute()
    {

        //_enemyBossAnimations.MoveAnimation(true);

        //var attackDistance = Vector3.Distance(_enemyBoss.transform.position, _target.transform.position);
        _enemyBoss.Seek();
        Debug.Log("Enemy SeekState Execute");
        if (Vector3.Distance(_enemyBoss.transform.position, _target.transform.position) <= _enemyBoss.attackRange)
        {
            _fsm.Transition(_attackStateEnemy);
            Debug.Log("Transition to Attack");
        }
        else if (Vector3.Distance(_enemyBoss.transform.position, _target.transform.position) >= _enemyBoss.attackRange)
        {
            _fsm.Transition(_idleStateEnemy);
        }

    }

    public override void Sleep()
    {
        Debug.Log("Enemy SeekState Sleep");

    }
}
