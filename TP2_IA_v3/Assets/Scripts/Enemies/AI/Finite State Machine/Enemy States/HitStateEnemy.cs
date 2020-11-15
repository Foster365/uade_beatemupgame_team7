using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStateEnemy<T> : FSMState<T>
{
    EnemyBoss _enemyBoss;
    EnemyBossAnim _enemyBossAnimations;
    Player _target;


    Roulette _roulette;
    Dictionary<Node, int> _rouletteNodes = new Dictionary<Node, int>();
    Node _initNode;


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
        Debug.Log("Enemy KickState Awake");

        _roulette = new Roulette();

        ActionNode attack = new ActionNode(Attack);
        ActionNode idle = new ActionNode(Idle);
        ActionNode block = new ActionNode(Block);

        _rouletteNodes.Add(attack, 90);
        _rouletteNodes.Add(idle, 50);
        _rouletteNodes.Add(block, 40);

        ActionNode rouletteAction = new ActionNode(RouletteAction);


    }

    public override void Execute()
    {
        Debug.Log("Enemy KickState Execute");
        _enemyBossAnimations.KickAnimation();
        RouletteAction();
        
    }

    public override void Sleep()
    {
        Debug.Log("Enemy KickState Sleep");        
    }

    void RouletteAction()
    {
        Node _nodeRoulette = _roulette.Run(_rouletteNodes);
        _nodeRoulette.Execute();
    }

    void Attack()
    {
        _fsm.Transition(_attackStateEnemy);
    }

    void Idle()
    {
        _fsm.Transition(_idleStateEnemy);
    }

    void Block()
    {
        _fsm.Transition(_blockStateEnemy);
    }
}
