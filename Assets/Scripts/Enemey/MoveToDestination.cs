using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToDestination : MonoBehaviour
{

    public Transform Dest = null;
    private NavMeshAgent thisAgent = null;

    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        thisAgent.SetDestination(Dest.position);
    }
}