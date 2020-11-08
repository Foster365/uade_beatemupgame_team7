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

    Roulette _roulette;
    Dictionary<Node, int> _rouletteNodes = new Dictionary<Node, int>();
    Node _initNode;
    Enemy _enemy;

    EnemyAnimations _enemyAnimations;

    private Node initialNode;
    LineOfSight sight;
    Seek seek;
    Flee flee;
    ObstacleAvoidance obstacleavoidance;
    float timer;
    //EnemyCombat combat;
    public float waitime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }
    private void Start()
    {
        _fsm = new FSM<string>();

        //IdleStateEnemy<string> idleStateEnemy=new IdleStateEnemy<string>(_enemyAnimations);
        //PatrolStateEnemy<string> patrolStateEnemy=new PatrolStateEnemy<string>(_enemy, _enemyAnimations);
        //SeekStateEnemy<string> seekStateEnemy=new SeekStateEnemy<string>(_enemy, _enemyAnimations);
        //KickStateEnemy<string> kickStateEnemy=new KickStateEnemy<string>(_enemy, _enemyAnimations);
        //PunchStateEnemy<string> punchStateEnemy=new PunchStateEnemy<string>(_enemy, _enemyAnimations);
        //DieStateEnemy<string> dieStateEnemy=new DieStateEnemy<string>(_enemy, _enemyAnimations);

        //idleStateEnemy.AddTransition("PatrolStateEnemy", patrolStateEnemy);        
        //patrolStateEnemy.AddTransition("IdleStateEnemy", idleStateEnemy)                                                                                                   ;

        //patrolStateEnemy.AddTransition("SeekStateEnemy", seekStateEnemy);
        // seekStateEnemy.AddTransition("AttackStateEnemy", initialNode);
        // initialNode.AddTransition("DieStateEnemy", dieStateEnemy);

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

    private void RouletteWheel()
    {

        _roulette = new Roulette();

        ActionNode aPunch = new ActionNode(_enemy.APunch);
        ActionNode bPunch = new ActionNode(_enemy.BPunch);
        ActionNode Kick = new ActionNode(_enemy.Kick);

        _rouletteNodes.Add(aPunch, 30);
        _rouletteNodes.Add(bPunch, 35);
        _rouletteNodes.Add(Kick, 50);

        ActionNode rouletteAction = new ActionNode(RouletteAction);

    }

    private void CreateDecisionTree()
    {
        ActionNode Follow = new ActionNode(Seek);
        ActionNode Wait = new ActionNode(Idle);
        ActionNode Patrol = new ActionNode(Patroling);
        ActionNode Flee = new ActionNode(Fleeing);

        ActionNode Attack = new ActionNode(_enemy.Attack);
        //ActionNode APunch = new ActionNode(_enemy.APunch);
        //ActionNode BPunch = new ActionNode(_enemy.BPunch);
        //ActionNode Kick = new ActionNode(_enemy.Kick);
        ActionNode Block = new ActionNode(_enemy.Block);

        QuestionNode doIHaveIdle = new QuestionNode(() => timer >= waitime, Wait, Patrol);
        QuestionNode doIHaveTarget = new QuestionNode(() => sight.targetInSight, Follow, doIHaveIdle);
        QuestionNode doIHaveHealth = new QuestionNode(() => (_enemy.CurrentHealth / _enemy.maxHealth) <= 0.3f, Flee, doIHaveTarget);
        QuestionNode shouldIAttack = new QuestionNode(_enemy.ShouldIAttack, Attack, Follow);

        //QuestionNode HowShouldIAttack = new QuestionNode(_enemy.HowShouldIAttack, rouletteAction, kick);
        //Armar esta parte bien, falta hacer que se relacione como corresponde y
        //y que llame a los estados que corresponden (Ver si conviene poner las funciones de los actionNodes
        //en la clase main o si conviene ponerlas en cada estado, hacer una referencia y llamarlos desde ahí)

        initialNode = doIHaveHealth;
    }

    public void RouletteAction()
    {
        Node nodeRoulette = _roulette.Run(_rouletteNodes);
        nodeRoulette.Execute();
    }

    private void Attack()
    {
        obstacleavoidance.move = false;
        seek.move = true;
        //combat.attack = true;
    }

    private void Seek()
    {
        obstacleavoidance.move = false;
        if (Vector3.Distance(transform.position, sight.Target.position) > 1f)
        {
            seek.move = true;
            //Debug.Log("Move Animation");
        }
        else
        {
            seek.move = false;
        }
        //combat.attack = true;
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
        //combat.attack = false;
    }


    private void Idle()
    {
        seek.move = false;
        obstacleavoidance.move = false;
        timer += Time.deltaTime;

        if (timer >= waitime + 5)
        {
            timer = 0;
        }

        //combat.attack = false;
    }

    private void Patroling()
    {
        seek.move = false;
        obstacleavoidance.move = true;
        timer += Time.deltaTime;
        _enemyAnimations.MoveAnimation(true);
        //combat.attack = false;
    }
}