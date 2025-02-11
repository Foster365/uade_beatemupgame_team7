﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAStar : MonoBehaviour
{
    public LayerMask mask;
    public float distanceMax;
    public float radius;
    public Vector3 offset;
    private Seek pj;
    List<Vector3> _listVector;
    AStar<Vector3> _aStarVector = new AStar<Vector3>();
    public GameObject finit;

    private void Awake()
    {
        pj = gameObject.GetComponent<Seek>();
    }

    public void PathFindingAStarVector()
    {
        _listVector = _aStarVector.Run(transform.position, SatisfiesVector, GetNeighboursVector, GetCostVector, HeuristicVector);
        pj.SetWayPoints(_listVector);
    }
 
    float HeuristicVector(Vector3 curr)
    {
        return Vector3.Distance(curr, finit.transform.position);
    }
    float GetCostVector(Vector3 p, Vector3 c)
    {
        return 1;
    }
    List<Vector3> GetNeighboursVector(Vector3 curr)
    {
        List<Vector3> list = new List<Vector3>();
        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                if (z == 0 && x == 0) continue;
                var newPos = new Vector3(curr.x + x, curr.y, curr.z + z);
                var dir = (newPos - curr);
                if (Physics.Raycast(curr, dir.normalized, dir.magnitude, mask)) continue;
                list.Add(newPos);
                //Debug.Log(list.Count);
            }
        }
        return list;
    }
    bool SatisfiesVector(Vector3 curr)
    {
        return Vector3.Distance(curr, finit.transform.position) < 1;
    }
    
    
    
    private void OnDrawGizmos()
    {
        Vector3 init = transform.position;
        Gizmos.color = Color.red;
        if (init != null)
            Gizmos.DrawSphere(init + offset, radius);
        if (finit != null)
            Gizmos.DrawSphere(finit.transform.position + offset, radius);
        
        if (_listVector != null)
        {
            Gizmos.color = Color.green;
            foreach (var item in _listVector)
            {
                if (item != init && item != finit.transform.position)
                    Gizmos.DrawSphere(item + offset, radius);
            }
        }
    }
}
