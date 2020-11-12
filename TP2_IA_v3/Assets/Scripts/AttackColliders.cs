using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackColliders : MonoBehaviour
{
    public Entity attacker;
    public string targetTag;
    public bool isKick;
    public bool isPunch;

    public GameObject hitFX;

    public void Awake()
    {
        attacker = GetComponentInParent<Entity>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Attack Trigger");
        if (other.gameObject.GetComponent<Entity>())
        {
            if (isKick) { other.gameObject.GetComponent<Entity>().TakeDamage(attacker.kickDamage); Debug.Log("Kick Damage"); }
            if (isPunch) { other.gameObject.GetComponent<Entity>().TakeDamage(attacker.punchDamage); Debug.Log("Punch Damage");}

        }

    }

   
}
