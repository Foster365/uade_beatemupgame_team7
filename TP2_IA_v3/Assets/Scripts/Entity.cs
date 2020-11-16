using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float kickDamage = 10;
    public float punchDamage = 5;
    public Rigidbody rb;

    public bool isPlayer;
    public float deathTime = 15f;
    public AudioClip hitFX;
    public AudioClip deathFX;

    public Animator _anim;
    public bool isDead = false;


    public void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        if (isPlayer) //Tuve que hardcodear para no complicar la solución
        {
            _anim = GetComponentInChildren<Animator>();
        }
        else
        {
            _anim = GetComponent<Animator>();
        }
        

    }
    public void TakeDamage(float dm)
    {
        currentHealth -= dm;
        AudioSource.PlayClipAtPoint(hitFX, transform.position);

        if (currentHealth <= 0f)
        {
            Die();
        }
        else if (!isDead){ _anim.SetTrigger("Damaged"); }
    }

    public void Die()
    {
        
        if (!isDead)
        {
            Debug.Log("Se murió");
            _anim.SetTrigger("Death");
            AudioSource.PlayClipAtPoint(deathFX, transform.position);
            Destroy(this.gameObject, deathTime);
        }
        
        isDead = true;

    }


}
