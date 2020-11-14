using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player.ChangePowerUp(PowerUps.Knife);
            Destroy(gameObject);
        }
    }
}
