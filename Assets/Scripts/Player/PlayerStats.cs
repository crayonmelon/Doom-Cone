using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Health = 10;
    public bool IsHolding;
    private bool isBeingHurt = false;

    public AudioClip hurt;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = .5f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="enemy") {
            isBeingHurt = true;
            Health -= Time.deltaTime * 2;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Health -= Time.deltaTime * 2;

            source.PlayOneShot(hurt, .5f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
            isBeingHurt = false;
    }

    private void FixedUpdate()
    {

        if (Health <= 10 && isBeingHurt == false)
        {
            Health += Time.deltaTime;
        }

        if (Health <= 0)
        {
            Respawn();
        }
    }




    public void Respawn()
    {
        Debug.Log("die");
        transform.position = new Vector3(51.5f, -0.5f, -42);
        Health = 10;
    }
}
