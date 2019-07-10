using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkullController : MonoBehaviour
{
    public float lookRadius = 15f;
    Transform target;
    public int speed = 10;

    void Start()
    {
        target = PlayerManager.instance.player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= lookRadius)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
    }
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
