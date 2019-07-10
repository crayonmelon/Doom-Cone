using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    private bool playerAround;
    private Transform target;
    private NavMeshAgent agent = null;
    private float timer;
   
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }

        if (playerAround == true)
        {
            agent.SetDestination(Vector3.zero);
        }
  
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            playerAround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerAround = false;
    }
    
}