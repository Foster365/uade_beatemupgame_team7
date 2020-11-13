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

    private HealthUI healthUIPlayer;

    public void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();

        if (isPlayer)
            healthUIPlayer = GetComponent<HealthUI>();

    }
    public void TakeDamage(float dm)
    {
        currentHealth -= dm;

        if (isPlayer)
            healthUIPlayer.DisplayHealth(currentHealth);

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
