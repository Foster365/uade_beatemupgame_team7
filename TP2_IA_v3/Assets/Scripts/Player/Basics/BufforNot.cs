using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufforNot : MonoBehaviour
{
    Roulette _roulette;
    Dictionary<string, int> _dic;
    Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _roulette = new Roulette();
        _dic = new Dictionary<string, int>();
        _dic.Add("Buff", 50);
        _dic.Add("DeBuff", 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            _player = Other.GetComponent<Player>();

            
            if (_roulette.Run(_dic) == "Buff")
            {
                _player = Other.GetComponent<Player>();
                _player.speed += 10;
                if (_player.speed > 20)
                {
                    _player.speed = 20;
                }

                Debug.Log("Buff");
            }
            else
            {
                _player.speed -= 10f;
                Debug.Log("Debuff");
                if(_player.speed <= 0)
                {
                    _player.speed = 5;
                }
            }
            Destroy(gameObject);
        }

    }
}
