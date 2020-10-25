using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Node initialNode;
    LineOfSight sight;
    Seek seek;
    ObstacleAvoidance obstacleavoidance;
    float timer;
    EnemyCombat combat;
    public float waitime;


    private void Awake()
    {
        sight = gameObject.GetComponent<LineOfSight>();
        seek = gameObject.GetComponent<Seek>();
        obstacleavoidance = gameObject.GetComponent<ObstacleAvoidance>();
        timer = 0;
        combat = gameObject.GetComponent<EnemyCombat>();
        CreateDecisionTree();
    }

    private void Update()
    {
        initialNode.Execute();
    }

    private void CreateDecisionTree()
    {
        ActionNode Hit = new ActionNode(Attack);
        ActionNode Wait = new ActionNode(Idle);
        ActionNode Patrol = new ActionNode(Patroling);

        QuestionNode doIHaveIdle = new QuestionNode(() => timer >= waitime, Wait, Patrol);
        QuestionNode doIHaveTarget = new QuestionNode(() => sight.targetInSight, Hit, doIHaveIdle);


        initialNode = doIHaveTarget;
    }

    private void Attack()
    {
        obstacleavoidance.move = false;
        seek.move = true;
        combat.attack = true;
    }


    private void Idle()
    {
        seek.move = false;
        obstacleavoidance.move = false;
        timer += Time.deltaTime;

        if (timer >= waitime + 5)
        {
            timer = 0;
        }

        combat.attack = false;
    }

    private void Patroling()
    {
        seek.move = false;
        obstacleavoidance.move = true;
        timer += Time.deltaTime;
        combat.attack = false;
    }
}
