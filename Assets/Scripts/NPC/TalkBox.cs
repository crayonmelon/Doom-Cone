using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBox : MonoBehaviour
{
    public Animator TargetAnimator = null;
    public string TriggerName = string.Empty;
    public GameObject canvas;
    public GameObject eIndicator;
    // Start is called before the first frame update

    //audio
    public AudioClip hello;
    private AudioSource source;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (canvas.active == true)
        {
            TargetAnimator.SetTrigger(TriggerName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            eIndicator.gameObject.SetActive(true);
      
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
         
            canvas.gameObject.SetActive(true);
            eIndicator.gameObject.SetActive(false);

            float volume = Random.Range(0.3f, .8f);
            source.PlayOneShot(hello, volume);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.gameObject.SetActive(false);
            eIndicator.gameObject.SetActive(false);
        }

    }

}
