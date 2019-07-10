using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSound : MonoBehaviour
{
    public AudioClip crashSoft;
    public AudioClip crashHard;
    private AudioSource source;

    private float lowPitch  = 0.5f;
    private float highPitch = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        float hitVol = collision.relativeVelocity.magnitude * 0.2f;
        source.pitch = Random.Range(lowPitch, highPitch);
        if (collision.relativeVelocity.magnitude < 10)
            source.PlayOneShot(crashSoft, hitVol);
        else
            source.PlayOneShot(crashHard, hitVol);
           
    }

}
