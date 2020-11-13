using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossController : MonoBehaviour
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
    public EnemyAnimations _enemyAnimations;

    private Node initialNode;
    LineOfSight sight;
    EnemyBoss _enemyBoss;

    public Transform _player;

    Seek seekBehaviour;
    ObstacleAvoidance obsAvoidanceBehaviour;
    LineOfSight lineOfSight;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }
    private void Start()
    {
        _fsm = new FSM<string>();

        seekBehaviour = gameObject.GetComponent<Seek>();
        obsAvoidanceBehaviour= gameObject.GetComponent<ObstacleAvoidance>();
        lineOfSight = gameObject.GetComponent<LineOfSight>();

        //sight = gameObject.GetComponent<LineOfSight>();
        //seek = gameObject.GetComponent<Seek>();
        //flee = gameObject.GetComponent<Flee>();
        //obstacleavoidance = gameObject.GetComponent<ObstacleAvoidance>();
        ////combat = gameObject.GetComponent<EnemyCombat>();
        //_enemy = gameObject.GetComponent<Enemy>();
        //timer = 0;

    }

    private void Update()
    {
        initialNode.Execute();
        _fsm.OnUpdate();
    }

    private void AttackFSM()
    {
        //KickStateEnemy<string> kickStateEnemy = new KickStateEnemy<string>(_enemy, _enemyAnimations);
        //PunchStateEnemy<string> punchStateEnemy = new PunchStateEnemy<string>(_enemy, _enemyAnimations);
        //BlockStateEnemy<string> blockStateEnemy = new BlockStateEnemy<string>(_enemy, _enemyAnimations);
        //AttackStateEnemy<string> attackStateEnemy = new AttackStateEnemy<string>(_enemy, _enemyAnimations, _fsm, "PunchStateEnemy", "KickStateEnemy");


        //attackStateEnemy.AddTransition("PunchStateEnemy", punchStateEnemy);
        //punchStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);
        //attackStateEnemy.AddTransition("KickStateEnemy", kickStateEnemy);
        //kickStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);
        //attackStateEnemy.AddTransition("BlockStateEnemy", blockStateEnemy);
        //blockStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);

        //_fsm.SetInit(attackStateEnemy);

    }

}
