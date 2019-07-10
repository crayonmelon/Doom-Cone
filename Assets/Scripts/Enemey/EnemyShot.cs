using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShot : MonoBehaviour
{
    public AudioClip getHit;
    private AudioSource source;
    private bool Isdead = false;

    public float jumpScareThrust = 2005f;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = .5f;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet" && PlayerManager.instance.player.GetComponent<PlayerStats>().IsHolding == false && Isdead == false)
        {
            PlayerManager.instance.score.GetComponent<Score>().StartScore();
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<EnemyController>().enabled = false;

            Rigidbody gameObjectsRigidBody = gameObject.GetComponent<Rigidbody>();
            gameObjectsRigidBody.isKinematic = false;

            gameObjectsRigidBody.AddForce(-transform.forward * jumpScareThrust);
            StartCoroutine(Died());

            //sound
            float volume = Random.Range(0.5f, 1.5f);
            source.PlayOneShot(getHit, volume);

            Isdead = true;
        }
    }

    private IEnumerator Died()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}