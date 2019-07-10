using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;
    public float shotSpeed = 2000f;
    public bool inSightPlayer;
    public Transform Dest = null;
    private NavMeshAgent thisAgent = null;


    private IEnumerator coroutine;
    
    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
   
    }
   
    IEnumerator Coroutine()
    {

        while (inSightPlayer == true)
        {
            yield return new WaitForSeconds(2);

            GameObject clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotSpeed);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inSightPlayer = true;
            StartCoroutine(Coroutine());
          
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
        
            thisAgent.SetDestination(Dest.position);
            inSightPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inSightPlayer = false;
        }
    }

}
