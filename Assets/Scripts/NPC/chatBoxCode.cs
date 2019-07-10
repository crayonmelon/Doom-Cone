using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatBoxCode : MonoBehaviour
{
    public GameObject chatIcon;
    public GameObject chatBox;
    public GameObject player;
    private bool isHolding;
   

    void Start()
    {
      
    }

    void Update()
    {
        isHolding = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            chatIcon.gameObject.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            chatIcon.gameObject.SetActive(false);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButtonDown("Interact"))
        {
            chatBox.gameObject.SetActive(true);
            print("E");

        }

        if (Input.GetButtonDown("Fire2") && other.tag == "Player" && chatBox.activeSelf && isHolding == false)
        {
            chatBox.transform.parent = player.transform;
            chatBox.transform.rotation = player.transform.rotation;
            chatBox.transform.position = player.transform.position;
            chatBox.transform.Translate(0, -.6f, 2);

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().IsHolding = true;
        }
    }
}






