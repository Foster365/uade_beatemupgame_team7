using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PowerUps
{
    BaseballBat,
    Knife,
    Star,
    None
}

public class Player : Entity, IMove
{
    public float speed;
    public float powerJump;
    public bool dead;
    private PowerUps _currentPU;
    [SerializeField] bool baseballbat;
    [SerializeField] bool star;
    [SerializeField] bool knife;

    public void Move(Vector3 dir)
    {
        if (!isDead)
        {
            dir.y = 0;
            rb.velocity = dir * speed;
            if (dir.x != 0 || dir.z != 0)
            transform.forward = dir;
        }
        
        
        
    }

    void Start()
    {
        ChangePowerUp(PowerUps.None);
    }
   
    public void ChangePowerUp(PowerUps powerUps)
    {
        _currentPU = powerUps;
    }
    private void Update()
    {
        switch (_currentPU) //Esto debería ser un método y no actualizarse todo el tiempo
        {
            case PowerUps.BaseballBat:
                punchDamage = 20;
                float time = 15;
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    ChangePowerUp(PowerUps.None);
                }
                break;

            case PowerUps.Knife:
                punchDamage = 15;
                time = 5;
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    ChangePowerUp(PowerUps.None);
                }
                break;

            case PowerUps.Star:
                time = 5;
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    ChangePowerUp(PowerUps.None);
                }
                break;

            case PowerUps.None:
                punchDamage = 5f;
                break;
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * powerJump, ForceMode.Impulse);
    }
}
