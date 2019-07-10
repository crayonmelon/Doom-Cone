using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject projectile;
    public float shotSpeed = 2000f;

    public AudioClip shot;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

    }
    void Update()
    {

        if(Input.GetButtonDown("Fire2") && gameObject.GetComponent<PickUp>().isPickedUp == true)
        {
            GameObject clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotSpeed);

            source.PlayOneShot(shot ,1f);
        }
    }
}
