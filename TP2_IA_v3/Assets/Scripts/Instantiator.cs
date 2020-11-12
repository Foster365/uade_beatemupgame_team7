using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    GameObject _enemys;
    public float creationTime = 2f, creationRange = 2f;
    void Start()
    {
        _enemys = GameObject.FindGameObjectWithTag("Enemy");
        InvokeRepeating("Create", 0, creationTime);
    }

    void Update()
    {
        
    }

    public void Create()
    {
        Vector3 SpawnP = new Vector3(0, 0, 0);
        SpawnP = transform.position + Random.onUnitSphere * creationRange;
        SpawnP = new Vector3(SpawnP.x, 2, SpawnP.z);

        GameObject _enemy = Instantiate(_enemys, SpawnP, Quaternion.identity);
    }
}
