using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    Player _player;
    bool powerUp = false;
    float timer = 5f;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            powerUp = true;
        }
    }
    private void Update()
    {
        if (powerUp == true && timer > 0)
        {
            _player.punchDamage += 10;
            timer -= Time.deltaTime;
        }
        else
        {
            powerUp = false;
            timer = 5f;
        }
    }
}
