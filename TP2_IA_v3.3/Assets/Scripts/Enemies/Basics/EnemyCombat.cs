using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    // public GameObject bullet;
    float timer;
    public float attackspeed;

    public bool attack = false;

    private void Awake()
    {
        timer = 0;
    }

    private void Update()
    {
        // timer += Time.deltaTime;
        // if (attack && timer >= attackspeed)
        // {
        //     Attack();
        //     timer = 0;
        // }
    }

    void Attack()
    {
        // GameObject bulletObject = Instantiate(bullet);
        // bulletObject.transform.position = transform.position + transform.forward;
        // bulletObject.transform.forward = transform.forward;
    }
}
