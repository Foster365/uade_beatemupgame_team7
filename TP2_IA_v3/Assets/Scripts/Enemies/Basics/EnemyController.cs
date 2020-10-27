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

        IdleStateEnemy<string> idleStateEnemy=new IdleStateEnemy<string>(_enemyAnimations);
        PatrolStateEnemy<string> patrolStateEnemy=new PatrolStateEnemy<string>(_enemy, _enemyAnimations);
        SeekStateEnemy<string> seekStateEnemy=new SeekStateEnemy<string>(_enemy, _enemyAnimations);
        AttackStateEnemy<string> attackStateEnemy=new AttackStateEnemy<string>(_enemy, _enemyAnimations);
        DieStateEnemy<string> dieStateEnemy=new DieStateEnemy<string>(_enemy, _enemyAnimations);

        idleStateEnemy.AddTransition("PatrolStateEnemy", patrolStateEnemy);        
        patrolStateEnemy.AddTransition("IdleStateEnemy", idleStateEnemy)                                                                                                   ;

        patrolStateEnemy.AddTransition("SeekStateEnemy", seekStateEnemy);
        seekStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);
        attackStateEnemy.AddTransition("DieStateEnemy", dieStateEnemy);

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
