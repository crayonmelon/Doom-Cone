using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionCompleteCounter : MonoBehaviour
{

    public int MissionsCompleted = 0;
    public int NumberOfMissions = 5;


    TextMeshProUGUI textmeshPro;
    public GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = text.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.text = "Mission Completed: " + MissionsCompleted + "/" + NumberOfMissions;
    }

    public void MissionComplete()
    {
        MissionsCompleted++;
    }
}
