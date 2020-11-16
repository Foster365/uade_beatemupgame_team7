using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieStateEnemy<T>:FSMState<T>
{

    EnemyBossAnim _enemyBossAnimations;
    public DieStateEnemy(EnemyBossAnim enemyBossAnimations)
    {

        _enemyBossAnimations = enemyBossAnimations;
    }

    public override void Awake()
    {
        Debug.Log("Enemy DieState Awake");
    }
    public override void Execute()
    {
        Debug.Log("Enemy DieState Execute");
        // _enemyBossAnimations.DeathAnimation();
    }
    public override void Sleep()
    {
        Debug.Log("Enemy DieState Sleep");
    }
}
