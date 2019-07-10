using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCounter : MonoBehaviour
{
    public AudioClip Celebration;
    private AudioSource source;
    public GameObject canvas;

    public bool IsMissionRewarded = false;

    public int Collisions;
    public GameObject MCCaller;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();

    }

    void Update()
    {
        if (Collisions > 80)
        {
            Debug.Log("Wow");
             if (IsMissionRewarded == false)
            {
                print("woot");   
                source.PlayOneShot(Celebration, 1f);
                MCCaller.GetComponent<MissionCompleteCounter>().MissionComplete();
                IsMissionRewarded = true;
                canvas.SetActive(true);

            }
        }
    }

    public void CollisionDetected(childCollider childcollider)
    {
        Collisions++;
    }
        
}
