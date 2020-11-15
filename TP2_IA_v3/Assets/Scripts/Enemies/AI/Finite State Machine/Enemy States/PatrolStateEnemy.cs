using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolStateEnemy<T>:FSMState<T>
{
    EnemyBoss _enemyBoss;
    EnemyBossAnim _enemyBossAnimations;
    Player _target;

    FSM<T> _fsm;
    T _idleStateEnemy;
    T _seekStateEnemy;

    public PatrolStateEnemy(EnemyBoss enemyBoss, EnemyBossAnim enemyBossAnimations, Player target, FSM<T> fsm, T idleStateEnemy, T seekStateEnemy)
    {
        _enemyBoss = enemyBoss;
        _enemyBossAnimations = enemyBossAnimations;
        _target = target;

        _fsm = fsm;
        _idleStateEnemy = idleStateEnemy;
        _seekStateEnemy = seekStateEnemy;

    }
    
    public override void Awake()
    {
       // Debug.Log("Enemy Patrol State Awake");

    }
    public override void Execute()
    {
        _enemyBoss.Patrolling();
        if (_enemyBoss.Line_Of_Sight.targetInSight)
        {
            _fsm.Transition(_seekStateEnemy);
            Debug.Log("Sight");
        }
      //  else if(!_enemyBoss.Line_Of_Sight.targetInSight)
           // Debug.Log("Not in sight");
        //_enemyBoss.GoToWaypoint();
        //_enemyBossAnimations.MoveAnimation(true);
      //  Debug.Log("Enemy Patrol State Execute");
        //_enemyBoss.GoToWaypoint();
        //_enemyBossAnimations.MoveAnimation(true);
        //Poner iteraciones. Valor de enemycontroller que vaya disminuyendo
    }

    public override void Sleep()
    {
        Debug.Log("Enemy Patrol State Sleep");
    }
    
}