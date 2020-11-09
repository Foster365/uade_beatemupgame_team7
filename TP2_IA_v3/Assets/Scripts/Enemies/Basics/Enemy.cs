using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    float currentHealth;
    public bool dead;
    public float movementSpeed;
    bool _isMoving;

    EnemyAnimations _enemyAnim;
    Animator _animator;
    Transform _target;

    public float attackRange;
    float currentAttackTime;
    float defaultAttackTime;

    bool attackTarget;

    //Waypoint System (Patrol) variables
    public List<Transform> Waypoints;
    public float distance;
    int _nextWp = 0;
    int _indexModifier = 1;
    //

    //Line of Sight Variables
    [SerializeField]
    float LOSRadius, angle;

    [SerializeField]
    LayerMask layer;
    //

    Transform _transform;
    Rigidbody _rigidbody;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();

        _enemyAnim = GetComponent<EnemyAnimations>();
        _animator = GetComponent<Animator>();

    }

    private void Start()
    {
        CurrentHealth = maxHealth;

        _target = GameObject.FindWithTag(CharacterTags.PLAYER_TAG).transform;

        currentAttackTime = defaultAttackTime;
    }

    public void Move(Vector3 dir)
    {

        dir.y = 0;
        _rigidbody.velocity = dir * movementSpeed;
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
        // _enemyAnimation.RunAnimation();
        _isMoving = true;

    }

    //public void Attack()
    //{
    //    Debug.Log("Attacking player");
    //    _animator.SetTrigger(EnemyAnimationTags.ENEMY_APUNCH);
    //}

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

    public bool LineOfSight(Transform target)
    {

        Vector3 diff = transform.position - target.transform.position;
        float distance = diff.magnitude;
        if (distance > LOSRadius) return false;
        float angleToTarget = Vector3.Angle(transform.position, diff.normalized);
        if (angleToTarget > angle / 2) return false;
        if (Physics.Raycast(transform.position, diff, distance, layer)) return true;

        return true;

    }

    public bool ShouldIAttack()
    {
        Debug.Log("Should I Attack?");
        attackTarget=Vector3.Distance(transform.position, _target.position) > attackRange ? true : false;
        Debug.Log("Attack" + attackTarget);
        return attackTarget;
    }

    public void APunch()
    {
        _enemyAnim.APunchAnimation();
        //Punch code   
    }

    public void BPunch()
    {
        _enemyAnim.BPunchAnimation();
        //Punch code   
    }

    public void Kick()
    {
        _enemyAnim.KickAnimation();
        //Kick code
    }

    public void Block()
    {
        _enemyAnim.BlockAnimation();
    }

    public void GetDamage()
    {
        _enemyAnim.DamageAnimation();
    }

    public void Idle()
    {
        _enemyAnim.IdleAnimation();
    }

    public void Die()
    {
        _enemyAnim.DeathAnimation();
    }
}
