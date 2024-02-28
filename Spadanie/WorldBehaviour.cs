using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldBehaviour : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public void Start(){
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void PauseGame(){
        Time.timeScale = 0;
        GameIsPaused = true;
   
    }
    public void ContinueGame(){
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void Update(){
    if (Input.GetKeyDown(KeyCode.Escape)){
        if (GameIsPaused == true){
            ContinueGame();
            Debug.Log("Game should NOT be paused rn");
        } 
        else{
            PauseGame();
            Debug.Log("Game should be paused rn");
        }
    }
    if (Input.GetKeyDown(KeyCode.Alpha1)){
        if (GameIsPaused == true){
            Debug.Log("Game is paused so cant change speed");
        } 
        else{
            Time.timeScale = 0.01f;
            Debug.Log("Game should be at 0.01 speed");
        }
    }
    if (Input.GetKeyDown(KeyCode.Alpha2)){
        if (GameIsPaused == true){
            Debug.Log("Game is paused so cant change speed");
        } 
        else{
            Time.timeScale = 0.1f;
            Debug.Log("Game should be at 0.1 speed");
        }
    }
    if (Input.GetKeyDown(KeyCode.Alpha3)){
        if (GameIsPaused == true){
            Debug.Log("Game is paused so cant change speed");
        } 
        else{
            Time.timeScale = 0.5f;
            Debug.Log("Game should be at 0.5 speed");
        }
    }
    if (Input.GetKeyDown(KeyCode.Alpha4)){
        if (GameIsPaused == true){
            Debug.Log("Game is paused so cant change speed");
        } 
        else{
            Time.timeScale = 1f;
            Debug.Log("Game should be at normal speed");
        }
    }
    if (Input.GetKeyDown(KeyCode.Alpha5)){
        if (GameIsPaused == true){
            Debug.Log("Game is paused so cant change speed");
        } 
        else{
            Time.timeScale = 2f;
            Debug.Log("Game should be at 2x speed");
        }
    }
}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered collision with " + collision.gameObject.name);
        GameIsPaused = true;
        Time.timeScale = 0;

    }
}
