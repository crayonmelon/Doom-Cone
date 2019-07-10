using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public float shotSpeed = 200f;
    private bool isHolding;


    public BoxCollider Coll { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isHolding = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding;
        if (gameObject.activeSelf)
        {
            if (Input.GetButtonDown("Fire1") && transform.parent.tag == "MainCamera")
            {
                gameObject.AddComponent<BoxCollider>();
                Coll = GetComponent<BoxCollider>();

                Coll.size = new Vector3(8, 2.3f, .1f);
                Coll.center= new Vector3(-2.5f, -2, 0);

                gameObject.AddComponent<Rigidbody>();
                gameObject.transform.parent = null;
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotSpeed);

                Destroy(gameObject,5);

                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding = false;

            }

        }
    }
}
