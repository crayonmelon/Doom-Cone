using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.parent.GetComponent<ColliderCounter>().CollisionDetected(this);
    }
}
