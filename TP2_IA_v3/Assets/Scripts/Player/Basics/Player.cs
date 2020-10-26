using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IMove
{
    public float speed;
    public float powerJump;
    public float maxHealth = 100;
    private float currentHealth;
    public bool dead;
    Rigidbody _rb;
    //PlayerAnimation _playerAnimation;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        CurrentHealth = maxHealth;
        //_playerAnimation = GetComponent<PlayerAnimation>();
    }
    public void Move(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
        if(dir.x != 0 || dir.z != 0)
        transform.forward = dir;
        
        //Debug.Log(dir);
        //_playerAnimation.RunAnim(_rb.velocity.magnitude);
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }
    private void Die()
    {
        dead = true;

        SceneManager.LoadScene("Level");
    }
    public void Jump()
    {
        _rb.AddForce(Vector3.up * powerJump, ForceMode.Impulse);
    }
}
