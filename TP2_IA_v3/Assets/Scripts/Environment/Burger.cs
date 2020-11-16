using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player.currentHealth += 50;
            if (_player.currentHealth > _player.maxHealth)
            {
                _player.currentHealth = _player.maxHealth;
            }
            Destroy(gameObject);
        }
    }
}
