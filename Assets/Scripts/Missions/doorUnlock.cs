using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorUnlock : MonoBehaviour
{
    public GameObject door;

    public AudioClip doorOpenSound;
    public AudioClip PlayerTrigger;
    private AudioSource source;
    public GameObject VictoryCanvas;
    private bool doorOpen = false;

    public GameObject MCCaller;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "keys" && doorOpen == false)
        {
            door.SetActive(false);
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
