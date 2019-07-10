using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpWashingM : MonoBehaviour
{
    public GameObject player;
    public float shotSpeed = 200f;
    public bool isPickedUp = false;
    private bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");

        isHolding = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding;
    }

    // Update is called once per frame
    void Update()
    {
        isHolding = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding;

        if (Input.GetButtonDown("Fire1") && isPickedUp == true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.parent = null;
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotSpeed);
            
            isPickedUp = false;

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire2") && other.tag == "Player" && isHolding == false)
        {

            gameObject.transform.parent = player.transform;
            gameObject.transform.rotation = player.transform.rotation;
            gameObject.transform.position = player.transform.position;
            gameObject.transform.Translate(0, -.7f, 2);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<fleePlayer>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            
            isPickedUp = true;

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding = true;

            if (GetComponent<lookAtPlayer>() != null)
            {
                GetComponent<lookAtPlayer>().enabled = false;
            }
        }


    }
}
