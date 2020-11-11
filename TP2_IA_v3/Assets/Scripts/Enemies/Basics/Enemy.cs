using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    
    public bool dead;
    public float movementSpeed;
    bool _isMoving;

    EnemyAnimations _enemyAnim;
    Transform _target;

    public float attackRange;
    float currentAttackTime;
    public float defaultAttackTime = 1.2f;

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

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _enemyAnim = GetComponent<EnemyAnimations>();
        

        _target = GameObject.FindWithTag(CharacterTags.PLAYER_TAG).transform;

        currentAttackTime = defaultAttackTime;
    }

    public void Move(Vector3 dir)
    {

        dir.y = 0;
        rb.velocity = dir * movementSpeed;
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.2f);
        // _enemyAnimation.RunAnimation();
        _isMoving = true;

    }

    public void Attack()
    {
        currentAttackTime += Time.deltaTime;

        if(currentAttackTime>=defaultAttackTime)
            _enemyAnim.APunchAnimation();

        currentAttackTime = 0;
        Debug.Log("Punch Anim");
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
        if (Vector3.Distance(transform.position, _target.position) < attackRange)
            attackTarget = true;
        else
            attackTarget = false;

        Debug.Log("Attack" + attackTarget);

        return attackTarget;
    }

    public void APunch()
    {
        _enemyAnim.APunchAnimation();
        Debug.Log("Enemy Punch A");
        //Punch code   
    }

    public void BPunch()
    {
        _enemyAnim.BPunchAnimation();
        Debug.Log("Enemy Punch B");
        //Punch code   
    }

    public void Kick()
    {
        _enemyAnim.KickAnimation();
        Debug.Log("Enemy Kick");
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

    private void Die()
    {
        _enemyAnim.DeathAnimation();
        Destroy(this, 5f);
        //Animation

    }

}
