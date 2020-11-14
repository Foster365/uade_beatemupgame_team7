using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Rigidbody _rigidbody;
    Animator _animator;
    public AudioClip slashFX1;
    public AudioClip slashFX2;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        _animator.SetBool("Movement", move);
    }

    public void Punch_1()
    {
        _animator.SetTrigger("Punch 1");
        AudioSource.PlayClipAtPoint(slashFX1, transform.position);
    }

    public void Punch_2()
    {
        _animator.SetTrigger("Punch 2");
        AudioSource.PlayClipAtPoint(slashFX1, transform.position);
    }

    public void Punch_3()
    {
        _animator.SetTrigger("Punch 3");
        AudioSource.PlayClipAtPoint(slashFX2, transform.position);
    }

    public void Kick_1()
    {
        _animator.SetTrigger("Kick 1");
        AudioSource.PlayClipAtPoint(slashFX1, transform.position);
    }

    public void Kick_2()
    {
        _animator.SetTrigger("Kick 2");
        AudioSource.PlayClipAtPoint(slashFX2, transform.position);
    }
}
