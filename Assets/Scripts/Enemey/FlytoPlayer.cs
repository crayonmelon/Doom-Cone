using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlytoPlayer : MonoBehaviour
{
    public Transform target;
    public int speed = 10;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
        }
    }
}
