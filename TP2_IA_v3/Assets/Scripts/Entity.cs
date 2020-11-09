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

    public void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();

    }
    public void TakeDamage(float dm)
    {
        currentHealth -= dm;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this, 5f);
        //Animation
       
    }


}
