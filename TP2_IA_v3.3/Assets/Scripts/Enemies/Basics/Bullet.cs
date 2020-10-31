using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f;
    public float attackDamage = 101f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider Other)
    {
      
            if (Other.GetComponent<Player>().dead != true)
                Other.GetComponent<Player>().TakeDamage(attackDamage);
       
        
        Destroy(gameObject);
    }
}
