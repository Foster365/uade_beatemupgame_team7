using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateEnemy<T>:FSMState<T>
{

    EnemyBoss _enemyBoss;
    EnemyBossAnim _enemyBossAnim;
    Player _target;

    Roulette _roulette;
    Dictionary<Node, int> _rouletteNodes = new Dictionary<Node, int>();
    Node _initNode;

    FSM<T> _fsm;
    T _seekStateEnemy;
    T _blockStateEnemy;
    T _hitStateEnemy;
    T _dieStateEnemy;

    public AttackStateEnemy(EnemyBoss enemyBoss, EnemyBossAnim enemyBossAnim, Player target, FSM<T> fsm, T seekStateEnemy, T blockStateEnemy,
    T hitStateEnemy, T dieStateEnemy)
    {
        _enemyBoss = enemyBoss;
        _enemyBossAnim = enemyBossAnim;
        _target = target;

        _fsm = fsm;
        _seekStateEnemy = seekStateEnemy;
        _blockStateEnemy = blockStateEnemy;
        _hitStateEnemy = hitStateEnemy;
        _dieStateEnemy = dieStateEnemy;
    }

    public override void Awake()
    {
        Debug.Log("Enemy AttackState Awake");
        _enemyBossAnim.MoveAnimation(false);
        _enemyBossAnim.RunAnimation(false);
        CreateRoulette();
    }

    public override void Execute()
    {
        Debug.Log("Enemy AttackState Execute");
        RouletteAction();
        if(Vector3.Distance(_enemyBoss.transform.position, _target.transform.position) >= _enemyBoss.attackRange)
            _fsm.Transition(_seekStateEnemy);
        //else if ()
        //    _fsm.Transition(_blockStateEnemy);
        //else if (_target.TakeDamage(_target.punchDamage) || _target.TakeDamage(_target.kickDamage))
            //_fsm.Transition(_hitStateEnemy);
        else if (_enemyBoss.currentHealth <= 0)
            _fsm.Transition(_dieStateEnemy);

    }

    public override void Sleep()
    {
        Debug.Log("Enemy AttackState Sleep");
    }

    public void RouletteAction()
    {
        Node nodeRoulette = _roulette.Run(_rouletteNodes);
        nodeRoulette.Execute();
    }

    public void CreateRoulette()
    {
        Debug.Log("Ruleta Enemy Creada");
        _roulette = new Roulette();

        ActionNode aPunch = new ActionNode(_enemyBoss.APunch);
        ActionNode bPunch = new ActionNode(_enemyBoss.BPunch);
        ActionNode Kick = new ActionNode(_enemyBoss.Kick);

        _rouletteNodes.Add(aPunch, 30);
        _rouletteNodes.Add(bPunch, 35);
        _rouletteNodes.Add(Kick, 50);

        ActionNode rouletteAction = new ActionNode(RouletteAction);

    }

}
