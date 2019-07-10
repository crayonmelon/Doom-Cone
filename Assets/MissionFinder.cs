using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MissionFinder : MonoBehaviour
{
    public int MissionsCompleted = 0;
    public int NumberOfMissions = 5;

    TextMeshProUGUI textmeshPro;
    public GameObject missionFinder;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        MissionsCompleted = missionFinder.GetComponent<MissionCompleteCounter>().MissionsCompleted;

        textmeshPro.text = "Mission Completed: " + MissionsCompleted + "/" + NumberOfMissions;
    }
}
