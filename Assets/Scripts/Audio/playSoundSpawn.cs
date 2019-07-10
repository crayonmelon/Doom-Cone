using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundSpawn : MonoBehaviour
{

    public AudioClip SpawnSound;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.PlayOneShot(SpawnSound, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
