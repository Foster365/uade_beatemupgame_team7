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
        _rigidbody=GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _fsm=new FSM<string>();

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
        flee = gameObject.GetComponent<Flee>();
        obstacleavoidance = gameObject.GetComponent<ObstacleAvoidance>();
        timer = 0;
        //combat = gameObject.GetComponent<EnemyCombat>();
        CreateDecisionTree();
    }

    private void Update()
    {
        initialNode.Execute();
        //_enemy.GoToWaypoint();
    }

    private void CreateDecisionTree()
    {
        ActionNode Follow = new ActionNode(Seek);
        ActionNode Wait = new ActionNode(Idle);
        ActionNode Patrol = new ActionNode(Patroling);
        ActionNode Flee = new ActionNode(Fleeing);

        QuestionNode doIHaveIdle = new QuestionNode(() => timer >= waitime, Wait, Patrol);
        QuestionNode doIHaveTarget = new QuestionNode(() => sight.targetInSight, Follow, doIHaveIdle);
        QuestionNode doIHaveHealth = new QuestionNode(() => (_enemy.CurrentHealth / _enemy.maxHealth) <= 0.3f, Flee, doIHaveTarget);


        initialNode = doIHaveTarget;
    }

    private void Seek()
    {
        obstacleavoidance.move = false;
        seek.move = true;
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
        //combat.attack = false;
    }
}
