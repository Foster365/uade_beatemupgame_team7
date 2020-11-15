using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliders : MonoBehaviour
{
    public Entity attacker;
    //public string targetTag;
   // public bool isPlayer, isEnemy;
    public bool isKick, isPunch;

    Enemy _enemy;
    Player _player;

    public GameObject hitFX;

    public void Start()
    {
        attacker = GetComponentInParent<Entity>();

    }

    //private void Update()
    //{
    //    DetectCollision();
    //}

    //public void DetectCollision()
    //{
    //    Collider[] fightColliders = Physics.OverlapSphere(transform.position, 1, 8);

    //    if (fightColliders.Length >= 0)
    //    {
    //        if (isEnemy)
    //        {
    //            if (isPunch)
    //            {
    //                _enemy.TakeDamage(_enemy.punchDamage);
    //                Debug.Log("Enemy Punch");
    //            }

    //            if (isKick)
    //            {
    //                _enemy.TakeDamage(_enemy.kickDamage);
    //                Debug.Log("Enemy Kick");
    //            }
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Attack Trigger");
        if (other.gameObject.GetComponent<Entity>())
        {
            if (isKick)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(attacker.kickDamage);
                //Debug.Log(attacker + "Kick Damage");
            }

            if (isPunch)
            {
                other.gameObject.GetComponent<Entity>().TakeDamage(attacker.punchDamage);
                //Debug.Log(attacker + "Punch Damage");
            }

        }

        gameObject.SetActive(false);

    }


}
