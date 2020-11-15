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
        dir.y = 0;
        rb.velocity = dir * speed;
        if(dir.x != 0 || dir.z != 0)
        transform.forward = dir;
        
        //Debug.Log(dir);
        //_playerAnimation.RunAnim(_rb.velocity.magnitude);
    }
    //public void TakeDamage(float damage)
    //{
    //    CurrentHealth -= damage;

    //    if (CurrentHealth <= 0f)
    //    {
    //        Die();
    //    }
    //}
    public void ChangePowerUp(PowerUps powerUps)
    {
        _currentPU = powerUps;
    }
    private void Update()
    {
        //switch (_currentPU)
        //{
        //    case PowerUps.BaseballBat:
        //        punchDamage += 10;
        //        float time = 5;
        //        time -= Time.deltaTime;
        //        if (time <= 0)
        //        {
        //            ChangePowerUp(PowerUps.None);
        //        }
        //        break;

        //    case PowerUps.Knife:
        //        punchDamage += 5;
        //        time = 5;
        //        time -= Time.deltaTime;
        //        if (time <= 0)
        //        {
        //            ChangePowerUp(PowerUps.None);
        //        }
        //        break;

        //    case PowerUps.Star:
        //        time = 5;
        //        time -= Time.deltaTime;
        //        if (time <= 0)
        //        {
        //            ChangePowerUp(PowerUps.None);
        //        }
        //        break;

        //    case PowerUps.None:
        //        break;
        //}
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * powerJump, ForceMode.Impulse);
    }
}
