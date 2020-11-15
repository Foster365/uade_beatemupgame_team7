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

    float maxCounter = 1f;
    float counter = 0;

    public IdleStateEnemy(EnemyBoss enemyBoss, EnemyBossAnim enemyBossAnimations, Player target, FSM<T> fsm, T patrolStateEnemy, T hitStateEnemy,
    /*T blockStateEnemy,*/ T dieStateEnemy)
    {
        _enemyBoss = enemyBoss;
        _enemyBossAnimations = enemyBossAnimations;
        _target = target;

        _fsm = fsm;
        _patrolStateEnemy = patrolStateEnemy;
        _hitStateEnemy = hitStateEnemy;
        //_blockStateEnemy = blockStateEnemy;
        _dieStateEnemy = dieStateEnemy;

    }

    public override void Awake()
    {
       // Debug.Log("Enemy Idle State Awake");

    }

    public override void Execute()
    {
        counter += Time.deltaTime;
        //bool inSight = _enemyBoss.LineOfSight(_target.transform);
      //  Debug.Log("Enemy Idle State Execute");
        //_enemyBossAnimations.IdleAnimation();
        IdleBehaviour();
        if (counter >= maxCounter)/*Vector3.Distance(_enemyBoss.transform.position, _target.transform.position) <= _enemyBoss.attackRange*/
            _fsm.Transition(_patrolStateEnemy);
        //else if (_target.TakeDamage(_target.punchDamage) || _target.TakeDamage(_target.kickDamage))
        //    _fsm.Transition(_hitStateEnemy);
        ////else if ()
        ////    _fsm.Transition(_blockStateEnemy);
        //else if (_enemyBoss.currentHealth <= 0)
        //    _fsm.Transition(_dieStateEnemy);


    }

    public override void Sleep()
    {
      //  Debug.Log("Enemy Idle State Sleep");
    }

    public void IdleBehaviour()
    {
        //_enemyBoss.SeekBehaviour.move = false;
        //_enemyBoss.ObsAvoidanceBehaviour.move = false;
        ////_idleTimer += Time.deltaTime;
        //_enemyBossAnimations.MoveAnimation(false);

        //if (_idleTimer >= _idleCountdown + 5)
        //{
        //    _idleTimer = 0;
        //}

        //combat.attack = false;
    }
}