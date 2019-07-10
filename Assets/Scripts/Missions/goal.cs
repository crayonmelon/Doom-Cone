using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    public GameObject door;

    public AudioClip doorOpenSound;
    public AudioClip PlayerTrigger;
    private AudioSource source;
    public GameObject VictoryCanvas;

    public GameObject MCCaller;
    private bool doorOpen = false;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball" && doorOpen == false)
        {
           // door.SetActive(false);
            source.PlayOneShot(doorOpenSound, 1f);
            VictoryCanvas.SetActive(true);
            MCCaller.GetComponent<MissionCompleteCounter>().MissionComplete();
            doorOpen = true;
        }

        if (other.tag == "Player")
        {
            source.PlayOneShot(PlayerTrigger, 1f);
        }
    }
}
