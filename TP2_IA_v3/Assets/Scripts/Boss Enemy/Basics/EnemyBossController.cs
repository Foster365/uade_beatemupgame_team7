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
    //public Transform target;
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

    EnemyBossAnim _enemyBossAnim;

    private Node initialNode;
    //LineOfSight sight;

    HealthUI _bossHealthUI;

    [SerializeField]
    EnemyBoss _enemyBoss;
    [SerializeField]
    Player _player;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_enemyBoss = GameObject.FindGameObjectWithTag(CharacterTags.BOSSENEMY_TAG).gameObject;
        _enemyBossAnim = gameObject.GetComponent<EnemyBossAnim>();
        //_player = GetComponent<Player>();

        _bossHealthUI = gameObject.GetComponentInChildren<HealthUI>();

        //sight = gameObject.GetComponent<LineOfSight>();
        //seek = gameObject.GetComponent<Seek>();
        //flee = gameObject.GetComponent<Flee>();
        //obstacleavoidance = gameObject.GetComponent<ObstacleAvoidance>();

    }
    private void Start()
    {
        _fsm = new FSM<string>();
        FSM();
    }

    private void Update()
    {
        _fsm.OnUpdate();
        _bossHealthUI.DisplayBossHealth(_enemyBoss.currentHealth);
    }

    private void FSM()
    {
        IdleStateEnemy<string> idleStateEnemy = new IdleStateEnemy<string>(_enemyBoss, _enemyBossAnim, _player, _fsm, "PatrolStateEnemy", "HitStateEnemy"/*, "BlockStateEnemy"*/, "DieStateEnemy");
        PatrolStateEnemy<string> patrolStateEnemy = new PatrolStateEnemy<string>(_enemyBoss, _enemyBossAnim, _player, _fsm, "IdleStateEnemy", "SeekStateEnemy");
        SeekStateEnemy<string> seekStateEnemy = new SeekStateEnemy<string>(_enemyBoss, _enemyBossAnim, _player, _fsm, "IdleStateEnemy", "AttackStateEnemy");
        AttackStateEnemy<string> attackStateEnemy = new AttackStateEnemy<string>(_enemyBoss, _enemyBossAnim, _player, _fsm, "SeekStateEnemy", "BlockStateEnemy", "HitStateEnemy", "DieStateEnemy");
        BlockStateEnemy<string> blockStateEnemy = new BlockStateEnemy<string>(_enemyBoss, _enemyBossAnim, _player, _fsm, "IdleStateEnemy", "AttackStateEnemy");
        HitStateEnemy<string> hitStateEnemy = new HitStateEnemy<string>(_enemyBoss, _enemyBossAnim, _player, _fsm, "AttackStateEnemy", "IdleStateEnemy", "BlockStateEnemy");
        DieStateEnemy<string> dieStateEnemy = new DieStateEnemy<string>(_enemyBossAnim);

        idleStateEnemy.AddTransition("PatrolStateEnemy", patrolStateEnemy);
        patrolStateEnemy.AddTransition("IdleStateEnemy", idleStateEnemy);

        patrolStateEnemy.AddTransition("SeekStateEnemy", seekStateEnemy);
        seekStateEnemy.AddTransition("PatrolStateEnemy", patrolStateEnemy);

        seekStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);
        attackStateEnemy.AddTransition("SeekStateEnemy", seekStateEnemy);
        attackStateEnemy.AddTransition("BlockStateEnemy", blockStateEnemy);

        //blockStateEnemy.AddTransition("IdleStateEnemy", idleStateEnemy);
        blockStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);

        idleStateEnemy.AddTransition("HitStateEnemy", hitStateEnemy);
        hitStateEnemy.AddTransition("IdleStateEnemy", idleStateEnemy);
        //hitStateEnemy.AddTransition("AttackStateEnemy", attackStateEnemy);
        hitStateEnemy.AddTransition("BlockStateEnemy", blockStateEnemy);

        attackStateEnemy.AddTransition("DieStateEnemy", dieStateEnemy);
        idleStateEnemy.AddTransition("DieStateEnemy", dieStateEnemy);

        _fsm.SetInit(idleStateEnemy);

    }

}
