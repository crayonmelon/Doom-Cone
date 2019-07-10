using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class healthSystem : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textmeshPro;
    public GameObject player;

    void Start()
    {
        textmeshPro = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.text = "Heath: " + (int)player.gameObject.GetComponent<PlayerStats>().Health;

    }
}
