using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullGotShot : MonoBehaviour
{
    private Score scoreText;
    public float jumpScareThrust = 2005f;

    private void Start()
    {
        scoreText = PlayerManager.instance.score.GetComponent<Score>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" && this.gameObject.GetComponent<Rigidbody>() == null)
        {
            scoreText.StartScore();
            print("Pain");
           
            gameObject.GetComponent<EnemySkullController>().enabled = false;
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
