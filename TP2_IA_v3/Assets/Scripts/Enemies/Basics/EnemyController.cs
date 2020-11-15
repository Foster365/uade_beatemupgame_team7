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
        //_rigidbody = GetComponent<Rigidbody>();
        _enemyAnimations = GetComponent<EnemyAnimations>();
    }
    private void Start()
    {

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

    }

    private void CreateDecisionTree()
    {
        ActionNode Follow = new ActionNode(Seek);
        ActionNode Wait = new ActionNode(Idle);
        ActionNode Patrol = new ActionNode(Patrolling);
        ActionNode Flee = new ActionNode(Fleeing);
        ActionNode Die = new ActionNode(_enemy.Die);

        ActionNode Attack = new ActionNode(_enemy.Attack);
        ActionNode Block = new ActionNode(_enemy.Block);

        //QuestionNode doIHaveIdle = new QuestionNode(() => timer >= waitTime, Wait, Patrol);
        QuestionNode shouldIAttack = new QuestionNode(_enemy.ShouldIAttack, Attack, Follow);
        QuestionNode doIHaveTarget = new QuestionNode(() => sight.targetInSight, shouldIAttack, Patrol);
        QuestionNode doIHaveHealth = new QuestionNode(() => _enemy.currentHealth >= 0, doIHaveTarget, Die);

        initialNode = doIHaveHealth;
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