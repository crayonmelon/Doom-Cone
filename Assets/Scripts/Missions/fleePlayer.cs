using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fleePlayer : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject Player;
    public float EnemyDistanceRun = 4.0f;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);


        
        if (distance < EnemyDistanceRun )   
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;

            _agent.SetDestination(newPos);
        }
        
    }
}
