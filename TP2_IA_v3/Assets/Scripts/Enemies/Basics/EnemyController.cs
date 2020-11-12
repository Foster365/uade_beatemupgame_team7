using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //Steering Behaviours Variables
    public Transform sbTarget;
    public Rigidbody sbRbTarget;
    public float sbTimePrediction;
    public float sbRange;
    public float sbRadius;
    public LayerMask sbLayermask;
    public float avoidWeight;
    //

    //Line of sight variables
    public Transform target;
    //

    //FSM variables
    FSM<string> _fsm;
    Rigidbody _rigidbody;
    //

    //Idle variables
    public float idleTimer;
    //

    //Patrol variables
    public float iterations;
    //

    //Roulette _roulette;
    //Dictionary<Node, int> _rouletteNodes = new Dictionary<Node, int>();
    //Node _initNode;

    Enemy _enemy;

    public EnemyAnimations _enemyAnimations;
   
    private Node initialNode;
    LineOfSight sight;
    Seek seek;
    Flee flee;
    ObstacleAvoidance obstacleavoidance;
    float timer;
    //EnemyCombat combat;
    public float waitTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }
    private void Start()
    {
        _fsm = new FSM<string>();

        sight = gameObject.GetComponent<LineOfSight>();
        seek = gameObject.GetComponent<Seek>();
        flee = gameObject.GetComponent<Flee>();
        obstacleavoidance = gameObject.GetComponent<ObstacleAvoidance>();
        //combat = gameObject.GetComponent<EnemyCombat>();
        _enemy = gameObject.GetComponent<Enemy>();
        timer = 0;

        CreateDecisionTree();
    }

    private void Update()
    {
        initialNode.Execute();
        _fsm.OnUpdate();
    }

    //private void RouletteWheel()
    //{

    //    _roulette = new Roulette();

    //    ActionNode aPunch = new ActionNode(_enemy.APunch);
    //    ActionNode bPunch = new ActionNode(_enemy.BPunch);
    //    ActionNode Kick = new ActionNode(_enemy.Kick);

    //    _rouletteNodes.Add(aPunch, 30);
    //    _rouletteNodes.Add(bPunch, 35);
    //    _rouletteNodes.Add(Kick, 50);

    //    ActionNode rouletteAction = new ActionNode(RouletteAction);

    //}

    public void FSMBuilder()
    {

    }

    private void CreateDecisionTree()
    {
        ActionNode Follow = new ActionNode(Seek);
        ActionNode Wait = new ActionNode(Idle);
        ActionNode Patrol = new ActionNode(Patrolling);
        ActionNode Flee = new ActionNode(Fleeing);

        ActionNode Attack = new ActionNode(_enemy.Attack);
        ActionNode Block = new ActionNode(_enemy.Block);

        //QuestionNode doIHaveIdle = new QuestionNode(() => timer >= waitTime, Wait, Patrol);
        QuestionNode shouldIAttack = new QuestionNode(_enemy.ShouldIAttack, Attack, Patrol);
        QuestionNode doIHaveTarget = new QuestionNode(() => sight.targetInSight, Follow, shouldIAttack);
        QuestionNode doIHaveHealth = new QuestionNode(() => (_enemy.currentHealth / _enemy.maxHealth) <= 0.3f, Flee, doIHaveTarget);

        //QuestionNode HowShouldIAttack = new QuestionNode(_enemy.HowShouldIAttack, rouletteAction, kick);
        //Armar esta parte bien, falta hacer que se relacione como corresponde y
        //y que llame a los estados que corresponden (Ver si conviene poner las funciones de los actionNodes
        //en la clase main o si conviene ponerlas en cada estado, hacer una referencia y llamarlos desde ahí)

        initialNode = doIHaveHealth;
    }

    private void AttackFSM()
    {
        KickStateEnemy<string> kickStateEnemy = new KickStateEnemy<string>(_enemy, _enemyAnimations);
        PunchStateEnemy<string> punchStateEnemy = new PunchStateEnemy<string>(_enemy, _enemyAnimations);
        BlockStateEnemy<string> blockStateEnemy = new BlockStateEnemy<string>(_enemy, _enemyAnimations);
        AttackStateEnemy<string> attackStateEnemy = new AttackStateEnemy<string>(_enemy, _enemyAnimations, _fsm, "PunchStateEnemy", "KickStateEnemy");


        attackStateEnemy.AddTransition("PunchStateEnemy", punchStateEnemy);
        punchStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);
        attackStateEnemy.AddTransition("KickStateEnemy", kickStateEnemy);
        kickStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);
        attackStateEnemy.AddTransition("BlockStateEnemy", blockStateEnemy);
        blockStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);

        _fsm.SetInit(attackStateEnemy);
        //obstacleavoidance.move = false;
        //seek.move = true;

        //_enemyAnimations.APunchAnimation();
        //combat.attack = true;
    }

    private void Seek()
    {
        obstacleavoidance.move = false;
        if(sight.Target != null)
        {
            if (Vector3.Distance(transform.position, sight.Target.position) > _enemy.attackRange)
            {
                seek.move = true;
                _enemyAnimations.MoveAnimation(true);
                //Debug.Log("Move Animation");
            }
            else
            {
                seek.move = false;
                _enemyAnimations.MoveAnimation(false);
            }
            //combat.attack = true;
        }
    }

    private void Fleeing()
    {
        flee.move = true;
        if (_enemy.dead)
        {
            flee.move = false;
        }
        seek.move = false;
        obstacleavoidance.move = false;
        _enemyAnimations.MoveAnimation(true);
        //combat.attack = false;
    }


    private void Idle()
    {
        seek.move = false;
        obstacleavoidance.move = false;
        timer += Time.deltaTime;
        _enemyAnimations.MoveAnimation(false);

        if (timer >= waitTime + 5)
        {
            timer = 0;
        }

        //combat.attack = false;
    }

    private void Patrolling()
    {
        seek.move = false;
        obstacleavoidance.move = true;
        timer += Time.deltaTime;
        _enemyAnimations.MoveAnimation(true);
        //combat.attack = false;
    }
}