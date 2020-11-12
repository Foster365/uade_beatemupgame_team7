using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy<T>:FSMState<T>
{
    Enemy _enemy;
    EnemyAnimations _enemyAnimations;

    Roulette _roulette;
    Dictionary<Node, int> _rouletteNodes = new Dictionary<Node, int>();
    Node _initNode;

    FSM<T> _fsm;
    T _punchState;
    T _kickState;

    public AttackStateEnemy(Enemy enemy, EnemyAnimations enemyAnimations, FSM<T> fsm, T punchState, T kickState)
    {
        _enemy=enemy;

        _fsm = fsm;
        _punchState = punchState;
        _kickState = kickState;

    }

    public override void Awake()
    {
        Debug.Log("Enemy AttackState Awake");

        _roulette = new Roulette();

        ActionNode aPunch = new ActionNode(_enemy.APunch);
        ActionNode bPunch = new ActionNode(_enemy.BPunch);
        ActionNode Kick = new ActionNode(_enemy.Kick);

        _rouletteNodes.Add(aPunch, 30);
        _rouletteNodes.Add(bPunch, 35);
        _rouletteNodes.Add(Kick, 50);

        ActionNode rouletteAction = new ActionNode(RouletteAction);

    }

    public override void Execute()
    {
        Debug.Log("Enemy AttackState Execute");
        Node nodeRoulette = _roulette.Run(_rouletteNodes);
        nodeRoulette.Execute();
        if(nodeRoulette==aPunch)

    }

    public override void Sleep()
    {
        Debug.Log("Enemy AttackState Sleep");
    }

    public void RouletteAction()
    {
    }

}
