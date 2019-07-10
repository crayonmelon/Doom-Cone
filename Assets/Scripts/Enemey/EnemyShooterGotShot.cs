using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooterGotShot : MonoBehaviour
{
    public Score scoreText;

    public float jumpScareThrust = 2005f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" && this.gameObject.GetComponent<Rigidbody>() == null)
        {
            scoreText.StartScore();

            print("Pain");
            gameObject.GetComponent<EnemyShoot>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            Rigidbody gameObjectsRigidBody = gameObject.AddComponent<Rigidbody>();

            gameObjectsRigidBody.AddForce(-transform.forward * jumpScareThrust);
            StartCoroutine(Died());

        }
    }

    private IEnumerator Died()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}