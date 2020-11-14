using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BaseballBat : MonoBehaviour
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
            _player.ChangePowerUp(PowerUps.BaseballBat);
            Destroy(gameObject);
        }
    }
}