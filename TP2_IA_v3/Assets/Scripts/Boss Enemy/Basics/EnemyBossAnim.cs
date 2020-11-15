using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossAnim : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    //Bool
    public void MoveAnimation(bool isMoving)
    {
        _animator.SetBool(BossEnemyAnimationTags.BOSSENEMY_MOVEMENT, isMoving);
    }
    //

    //Trigger
    public void RunAnimation(bool isSeek)
    {
        _animator.SetBool(BossEnemyAnimationTags.BOSSENEMY_SEEK, isSeek);
    }
    public void APunchAnimation()
    {
        _animator.SetTrigger(BossEnemyAnimationTags.BOSSENEMY_APUNCH);
    }

    public void BPunchAnimation()
    {
        _animator.SetTrigger(BossEnemyAnimationTags.BOSSENEMY_APUNCH);
    }

    public void KickAnimation()
    {
        _animator.SetTrigger(BossEnemyAnimationTags.BOSSENEMY_KICK);
    }

    public void BlockAnimation()
    {
        _animator.SetTrigger(BossEnemyAnimationTags.BOSSENEMY_BLOCK);
    }

    public void DamageAnimation()
    {
        _animator.SetTrigger(BossEnemyAnimationTags.BOSSENEMY_DAMAGED);
    }

    public void IdleAnimation()
    {
        _animator.SetTrigger(BossEnemyAnimationTags.BOSSENEMY_IDLE);
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger(BossEnemyAnimationTags.BOSSENEMY_DEATH);
    }
    //
    
}
