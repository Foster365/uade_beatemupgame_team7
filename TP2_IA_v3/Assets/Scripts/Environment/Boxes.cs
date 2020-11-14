using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    Transform _player;
    private int ActRange = 2;
    Roulette _roulette;
    Dictionary<GameObject, int> _dicNodes = new Dictionary<GameObject, int>();
    public GameObject _baseball;
    public GameObject _star;
    public GameObject _food;
    public GameObject _knife;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _roulette = new Roulette();
        _dicNodes.Add(_knife, 50);
        _dicNodes.Add(_star, 10);
        _dicNodes.Add(_baseball, 300);
        _dicNodes.Add(_food, 50);
    }

    void Update()
    {
        BreakBox();
    }

    private void BreakBox()
    {
        Vector3 distance = _player.position - transform.position;
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
        GameObject item = _roulette.Run(_dicNodes);
        Instantiate(item, new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
    }
}
