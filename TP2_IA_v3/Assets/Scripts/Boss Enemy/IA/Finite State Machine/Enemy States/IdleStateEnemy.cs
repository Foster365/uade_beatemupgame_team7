using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateEnemy<T>:FSMState<T>
{

    EnemyBoss _enemyBoss;
    EnemyBossAnim _enemyBossAnimations;
    Player _target;

    FSM<T> _fsm;
    T _patrolStateEnemy;
    T _hitStateEnemy;
    T _blockStateEnemy;
    T _dieStateEnemy;

    float maxCounter = 2f;
    float counter;
    
    public IdleStateEnemy(EnemyBoss enemyBoss, EnemyBossAnim enemyBossAnimations, Player target, FSM<T> fsm, T patrolStateEnemy, T hitStateEnemy,
    T dieStateEnemy)
    {
        _enemyBoss = enemyBoss;
        _enemyBossAnimations = enemyBossAnimations;
        _target = target;

        _fsm = fsm;
        _patrolStateEnemy = patrolStateEnemy;
        _hitStateEnemy = hitStateEnemy;
        _dieStateEnemy = dieStateEnemy;

    }

    public override void Awake()
    {
        counter = 0f;

    }

    public override void Execute()
    {
        counter += Time.deltaTime;
        IdleBehaviour();
        if (counter >= maxCounter)
            _fsm.Transition(_patrolStateEnemy);
        else if (_enemyBoss.currentHealth <= 0)
           _fsm.Transition(_dieStateEnemy);


    }

    public override void Sleep()
    {
        counter = 0;
    }

    public void IdleBehaviour()
    {
        _enemyBossAnimations.MoveAnimation(false);
        _enemyBoss.movementSpeed = 0;// Cuidado
    }
}