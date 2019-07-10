using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpEnemy : MonoBehaviour
{
    public AudioClip pickUp;
    public AudioClip throwAway;
    private AudioSource source;

    private GameObject player;
    public float shotSpeed = 200f;
    public bool isPickedUp = false;
    private bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        player = PlayerManager.instance.mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        isHolding = PlayerManager.instance.player.GetComponent<PlayerStats>().IsHolding;

        if (Input.GetButtonDown("Fire1") && isPickedUp == true)
        {

            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.transform.parent = null;
            

            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shotSpeed);

            isPickedUp = false;

            PlayerManager.instance.player.GetComponent<PlayerStats>().IsHolding = false;

            transform.gameObject.tag = "PlayerBullet";

            //sound
            float volume = Random.Range(0.3f, .8f);
            source.PlayOneShot(throwAway, volume);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire2") && other.tag == "Player" && isHolding == false)
        {
            gameObject.transform.parent = player.transform;
            gameObject.transform.rotation = player.transform.rotation;
            gameObject.transform.position = player.transform.position;
            gameObject.transform.Translate(0, -.7f, 2);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            isPickedUp = true;

            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<EnemyController>().enabled = false;

            PlayerManager.instance.player.GetComponent<PlayerStats>().IsHolding = true;

            if (GetComponent<lookAtPlayer>() != null)
            {
                GetComponent<lookAtPlayer>().enabled = false;
            }

            //sound 
            float volume = Random.Range(0.3f, .8f);
            source.PlayOneShot(pickUp, volume);
        }
    }
}
