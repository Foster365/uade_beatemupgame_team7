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

    public void PunchAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_PUNCH);
    }

    public void KickAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_KICK);
    }

    public void BlockAnimation()
    {
        _animator.SetTrigger(EnemyAnimationTags.ENEMY_BLOCK);
    }

}
