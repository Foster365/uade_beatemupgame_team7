using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Entity, IMove
{

    public bool dead;
    public float movementSpeed;
    bool _isMoving;

    EnemyBossAnim _bossEnemyAnim;
    Transform _target;

    ////
    //[SerializeField]
    //float sbR;

    //[SerializeField]
    //float angle;

    //[SerializeField]
    //LayerMask layer;

    public float attackRange;
    float currentAttackTime = 0;
    public float defaultAttackTime = 1.2f;

    bool attackTarget;

    //Waypoint System(Patrol) variables
    public List<Transform> Waypoints;
    public float distance;
    int _nextWp = 0;
    int _indexModifier = 1;

    [SerializeField]
    LayerMask layer;
    //

    Roulette _roulette;
    Dictionary<Node, int> _rouletteNodes = new Dictionary<Node, int>();
    Node _initNode;

    //Transform _transform;
    [SerializeField]
    Seek seekBehaviour;
    [SerializeField]
    ObstacleAvoidance obsAvoidanceBehaviour;
    [SerializeField]
    LineOfSight lineOfSight;

    //public Seek SeekBehaviour { get => seekBehaviour; set => seekBehaviour = gameObject.GetComponent<Seek>(); }
    //public ObstacleAvoidance ObsAvoidanceBehaviour { get => obsAvoidanceBehaviour; set => obsAvoidanceBehaviour = gameObject.GetComponent<ObstacleAvoidance>(); }
    public LineOfSight Line_Of_Sight { get => lineOfSight; }

    //Seek Behaviour
    float _idleTimer;
    [SerializeField]
    float _idleCountdown;
    //

    private void Start()
    {
        //_transform = GetComponent<Transform>();
        _bossEnemyAnim = GetComponent<EnemyBossAnim>();

        _target = GameObject.FindWithTag(CharacterTags.PLAYER_TAG).transform;

        //seekBehaviour = GetComponent<Seek>();
        //obsAvoidanceBehaviour = GetComponent<ObstacleAvoidance>();
        //lineOfSight = GetComponent<LineOfSight>();

        currentAttackTime = defaultAttackTime;

        RouletteWheel();

        _idleTimer = 0;
        //_player = GetComponent<Player>();

        //_attackCollider = GetComponent<AttackColliders>();


    }

    public void Move(Vector3 dir)
    {

        dir.y = 0;
        rb.velocity = dir * movementSpeed;
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
        _isMoving = true;

    }

    public void Attack()
    {
        currentAttackTime += Time.deltaTime;

        if (currentAttackTime >= defaultAttackTime)
            RouletteAction();

        currentAttackTime = 0;

        //Damage();
        Debug.Log("Punch Anim");
    }


    public void RouletteWheel()
    {
        _roulette = new Roulette();

        //ActionNode aPunch = new ActionNode(APunch);
        //ActionNode bPunch = new ActionNode(BPunch);
        //ActionNode kick = new ActionNode(Kick);

        //_rouletteNodes.Add(aPunch, 30);
        //_rouletteNodes.Add(bPunch, 35);
        //_rouletteNodes.Add(kick, 50);

        ActionNode rouletteAction = new ActionNode(RouletteAction);
    }

    public void RouletteAction()
    {
        Debug.Log("Entered in roulette");
        Node nodeRoulette = _roulette.Run(_rouletteNodes);
        nodeRoulette.Execute();
    }

    public void GoToWaypoint()
    {

        var waypoint = Waypoints[_nextWp];
        var waypointPosition = waypoint.position;
        waypointPosition.y = transform.position.y;
        Vector3 dir = waypointPosition - transform.position;
        if (dir.magnitude < distance)
        {
            if (_nextWp + _indexModifier >= Waypoints.Count || _nextWp + _indexModifier < 0)
                _indexModifier *= -1;
            _nextWp += _indexModifier;
        }
        Move(dir.normalized);
        // return dir;

    }

    public void APunch()
    {
        _bossEnemyAnim.APunchAnimation();
    }

    public void BPunch()
    {
        _bossEnemyAnim.BPunchAnimation();
    }

    public void Kick()
    {
        _bossEnemyAnim.KickAnimation();
    }

    public void Block()
    {
        _bossEnemyAnim.BlockAnimation();
    }

    public void GetDamage()
    {
        _bossEnemyAnim.DamageAnimation();
    }

    public void Idle()
    {
        _bossEnemyAnim.IdleAnimation();
    }

    public void Died()
    {
        _bossEnemyAnim.DeathAnimation();
    }

    public void Seek()
    {
        obsAvoidanceBehaviour.move = false;
        if (lineOfSight.Target != null)
        {
            seekBehaviour.move = true;

            if (Vector3.Distance(transform.position, lineOfSight.Target.position) > attackRange)
            {
                seekBehaviour.move = true;
                _bossEnemyAnim.RunAnimation(true);
                Debug.Log("Seek Animation");
            }
            else
            {
                seekBehaviour.move = false;
                _bossEnemyAnim.RunAnimation(false);
            }
            //combat.attack = true;
        }
    }

    //public void IdleBehaviour()
    //{
    //    seekBehaviour.move = false;
    //    obsAvoidanceBehaviour.move = false;
    //    _idleTimer += Time.deltaTime;
    //    _bossEnemyAnim.MoveAnimation(false);

    //    if (_idleTimer >= _idleCountdown + 5)
    //    {
    //        _idleTimer = 0;
    //    }

    //    //combat.attack = false;
    //}

    public void Patrolling()
    {
        seekBehaviour.move = false;
        obsAvoidanceBehaviour.move = true;
        _idleTimer += Time.deltaTime;
        _bossEnemyAnim.MoveAnimation(true);
        //combat.attack = false;
    }
}
