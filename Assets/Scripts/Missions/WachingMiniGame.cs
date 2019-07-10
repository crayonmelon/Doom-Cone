using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WachingMiniGame : MonoBehaviour
{

    public GameObject text;
    public GameObject canvas;
    TextMeshPro textmeshPro;

    public GameObject MCCaller;
    public GameObject GunReward;
    public bool IsMissionRewarded = false;

    public int numberOfWashingMachines = 5;
    private int collected = 0;
   
    public AudioClip Celebration;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
         textmeshPro = text.GetComponent<TextMeshPro>();
         source = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.text = "" + transform.childCount + "/" + numberOfWashingMachines + " Washing Machines";

        if (transform.childCount >= numberOfWashingMachines) 
        {
            

            if (IsMissionRewarded == false)
            {
                print("woot");
                GunReward.SetActive(true);
                textmeshPro.text = "YEAH, you did it";
                source.PlayOneShot(Celebration, 1f);
                MCCaller.GetComponent<MissionCompleteCounter>().MissionComplete();
                IsMissionRewarded = true;
                canvas.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WashingMachine")
        {
            other.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "WashingMachine")
        {
       //     other.transform.parent = null;
        }
    }
}
