using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    Transform player;
    private int ActRange = 2;
    Roulette _roulette;
    Dictionary<string, int> _dicNodes = new Dictionary<string, int>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _roulette = new Roulette();
        _dicNodes.Add("estrella", 100);
        _dicNodes.Add("comida", 50);
        _dicNodes.Add("arma", 30);
        _dicNodes.Add("armadura", 10);
    }

    void Update()
    {
        BreakBox();
    }

    private void BreakBox()
    {
        Vector3 distance = player.position - transform.position;
        if (distance.magnitude < ActRange && Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(gameObject);
            ExecuteRoulette();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ActRange);
    }
    void ExecuteRoulette()
    {
        string item = _roulette.Run(_dicNodes);
        Debug.Log(item);
    }
}
