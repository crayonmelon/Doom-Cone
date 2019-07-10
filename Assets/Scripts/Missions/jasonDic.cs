using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jasonDic : MonoBehaviour
{

    public AudioClip Celebration;
    private AudioSource source;
    public bool IsMissionRewarded = false;
    public GameObject MCCaller;
    public GameObject canvas;


    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jason" && IsMissionRewarded == false)
        {
            source.PlayOneShot(Celebration, 1f);
            MCCaller.GetComponent<MissionCompleteCounter>().MissionComplete();
            IsMissionRewarded = true;
            canvas.SetActive(true);

        }
    }
}
