using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTunnelSpawner : MonoBehaviour

{
    public GameObject Enemies;


    private void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "Player")
            Enemies.SetActive(true);
    }
}
