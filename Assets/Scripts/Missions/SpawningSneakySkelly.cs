using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSneakySkelly : MonoBehaviour
{
    public GameObject sneaker;
    public AudioClip Spawn;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

    }


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire2") && other.tag == "Player" )
        {
            sneaker.SetActive(true);
            source.PlayOneShot(Spawn, 2f);
        }

    }
}

