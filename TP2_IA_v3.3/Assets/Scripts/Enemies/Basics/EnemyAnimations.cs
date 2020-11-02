using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    
    public Animator _animator;
    
    public void MoveAnimation(bool isMoving)
    {
        _animator.SetBool("Moving", isMoving);
    }
    public void AttackAnimation(bool isAttacking)
    {
        _animator.SetBool("Attack", isAttacking);
    }
    public void APunchAnimation(bool isAPunch)
    {
        _animator.SetBool("APunch", isAPunch);
    }
    public void BPunchAnimation(bool isBPunch)
    {
        _animator.SetBool("BPunch", isBPunch);
    }
    
    public void AKickAnimation(bool isAKick)
    {
        _animator.SetBool("AKick", isAKick);
    }

    public void BKickAnimation(bool isBKick)
    {
        _animator.SetBool("BKick", isBKick);
    }

    public void BlockAnimation(bool isBLockng)
    {
        _animator.SetBool("Blocking", isBLockng);
    }

}
