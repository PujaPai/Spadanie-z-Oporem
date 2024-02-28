using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Control : MonoBehaviour
{
    public Transform transform;
    public Button startSimulation;
    public string controls = "Controls";

    void Start(){
        startSimulation.onClick.AddListener(simulationStart);
        
    }
    public void simulationStart(){
        Time.timeScale = 1;
        bool value = WorldBehaviour.GameIsPaused;
        WorldBehaviour.GameIsPaused = false;

        GameObject element = GameObject.Find(controls);

        // Check if the GameObject is found
        if (element != null)
        {
            // Disable the GameObject
            element.SetActive(false);
        }
    }
}
