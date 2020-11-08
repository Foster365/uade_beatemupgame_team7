using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{

    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(bool isMoving)
    {
        _animator.SetBool(EnemyAnimationTags.ENEMY_MOVEMENT, isMoving);
    }

    public void APunchAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_APUNCH);
    }

    public void BPunchAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_APUNCH);
    }

    public void KickAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_KICK);
    }

    public void BlockAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_BLOCK);
    }

    public void DamageAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_DAMAGED);
    }

    public void IdleAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_IDLE);
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_DEATH);
    }

}
