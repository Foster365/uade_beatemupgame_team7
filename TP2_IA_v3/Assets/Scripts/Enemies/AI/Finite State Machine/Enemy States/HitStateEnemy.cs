using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStateEnemy<T> : FSMState<T>
{
    EnemyBoss _enemyBoss;
    EnemyBossAnim _enemyBossAnimations;
    Player _target;


    

    FSM<T> _fsm;
    T _attackStateEnemy;
    T _idleStateEnemy;
    T _blockStateEnemy;

    public HitStateEnemy(EnemyBoss enemyBoss, EnemyBossAnim enemyBossAnimations, Player target, FSM<T> fsm,
    T attackStateEnemt, T idleStateEnemy, T blockStateEnemy)
    {

        _enemyBoss = enemyBoss;
        _enemyBossAnimations = enemyBossAnimations;
        _target = target;

        _fsm = fsm;
        _attackStateEnemy = attackStateEnemt;
        _idleStateEnemy = idleStateEnemy;
        _blockStateEnemy = blockStateEnemy;

    }

    public override void Awake()
    {
        


    }

    public override void Execute()
    {
        //Debug.Log("Enemy HitState Execute");
        //_enemyBossAnimations.HitAnimation();
       
        
    }

    public override void Sleep()
    {
        Debug.Log("Enemy KickState Sleep");        
    }

    

    void Attack()
    {
        _fsm.Transition(_attackStateEnemy);
    }

    
}
