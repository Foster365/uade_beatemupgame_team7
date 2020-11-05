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
    Dictionary<Node,int> _rouletteNodes=new Dictionary<Node, int>();
    Node _initNode;
    Enemy _enemy;
    EnemyAnimations _enemyAnimations;

    private Node initialNode;
    LineOfSight sight;
    Seek seek;
    ObstacleAvoidance obstacleavoidance;
    float timer;
    EnemyCombat combat;
    public float waitime;

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _fsm=new FSM<string>();

        _roulette=new Roulette();

        ActionNode punch=new ActionNode(_enemy.Punch);
        ActionNode kick=new ActionNode(_enemy.Kick);

        _rouletteNodes.Add(punch,30);
        _rouletteNodes.Add(kick,50);

        ActionNode rouletteAction=new ActionNode(RouletteAction);

        QuestionNode HowShouldIAttack=new QuestionNode(_enemy.HowShouldIAttack, punch, kick);
        _initNode=HowShouldIAttack;//Armar esta parte bien, falta hacer que se relacione como corresponde y
        //y que llame a los estados que corresponden (Ver si conviene poner las funciones de los actionNodes
        //en la clase main o si conviene ponerlas en cada estado, hacer una referencia y llamarlos desde ahí)

        IdleStateEnemy<string> idleStateEnemy=new IdleStateEnemy<string>(_enemyAnimations);
        PatrolStateEnemy<string> patrolStateEnemy=new PatrolStateEnemy<string>(_enemy, _enemyAnimations);
        SeekStateEnemy<string> seekStateEnemy=new SeekStateEnemy<string>(_enemy, _enemyAnimations);
        KickStateEnemy<string> kickStateEnemy=new KickStateEnemy<string>(_enemy, _enemyAnimations);
        PunchStateEnemy<string> punchStateEnemy=new PunchStateEnemy<string>(_enemy, _enemyAnimations);
        DieStateEnemy<string> dieStateEnemy=new DieStateEnemy<string>(_enemy, _enemyAnimations);

        idleStateEnemy.AddTransition("PatrolStateEnemy", patrolStateEnemy);        
        patrolStateEnemy.AddTransition("IdleStateEnemy", idleStateEnemy)                                                                                                   ;

        patrolStateEnemy.AddTransition("SeekStateEnemy", seekStateEnemy);
        // seekStateEnemy.AddTransition("AttackStateEnemy", initialNode);
        // initialNode.AddTransition("DieStateEnemy", dieStateEnemy);

        sight = gameObject.GetComponent<LineOfSight>();
        seek = gameObject.GetComponent<Seek>();
        obstacleavoidance = gameObject.GetComponent<ObstacleAvoidance>();
        timer = 0;
        combat = gameObject.GetComponent<EnemyCombat>();
        CreateDecisionTree();
    }

    private void Update()
    {
        // initialNode.Execute();
        _enemy.GoToWaypoint();
    }

    private void CreateDecisionTree()
    {
        ActionNode Hit = new ActionNode(Attack);
        ActionNode Wait = new ActionNode(Idle);
        ActionNode Patrol = new ActionNode(Patroling);

        QuestionNode doIHaveIdle = new QuestionNode(() => timer >= waitime, Wait, Patrol);
        QuestionNode doIHaveTarget = new QuestionNode(() => sight.targetInSight, Hit, doIHaveIdle);


        initialNode = doIHaveTarget;
    }

    public void RouletteAction()
    {
        Node nodeRoulette=_roulette.Run(_rouletteNodes);
        nodeRoulette.Execute();
    }

    private void Attack()
    {
        obstacleavoidance.move = false;
        seek.move = true;
        combat.attack = true;
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

        combat.attack = false;
    }

    private void Patroling()
    {
        seek.move = false;
        obstacleavoidance.move = true;
        timer += Time.deltaTime;
        combat.attack = false;
    }
}
