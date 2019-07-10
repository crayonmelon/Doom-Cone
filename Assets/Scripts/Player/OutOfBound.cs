using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    public AudioClip outOfBounds;
    private AudioSource source;

   
    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            source.PlayOneShot(outOfBounds, 1f);

            other.GetComponent<CharacterController>().enabled = false;
            PlayerManager.instance.player.GetComponent<PlayerStats>().Respawn();
            other.GetComponent<CharacterController>().enabled = true;
          
        }

        other.transform.position = new Vector3(51.5f, 20f, -142);


    }

} 
