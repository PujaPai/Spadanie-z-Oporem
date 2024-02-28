using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    public Transform obj;
    public TMP_Text heightText;
    public TMP_Text speedText;
    public TMP_Text accelText;
    public TMP_Text ePotText;
    public TMP_Text eKinText;
    public TMP_Text masaText;
    public TMP_Text radiusText;
    private bool isFunctionEnabled = true;
    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (isFunctionEnabled == true)
        {
            Dane();
        }
    }
    
    void Dane()
    {
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        string miliseconds = (t % 6000).ToString("f1");
        
        timerText.text = "Czas : " + seconds + " s";

        float h = obj.position.y;

        string height = (h - 1).ToString("f2");

        heightText.text = "Wysokość : " + height + " m";

        float v = obj.GetComponent<Rigidbody2D>().velocity.magnitude;

        string speed = (v).ToString("f2");

        speedText.text = "Prędkość : " + speed + " m/s";

        float a = v / t;

        string accel = (a).ToString("f2");

        accelText.text = "Przyspieszenie : " + accel + " m/s^2";

        float EP = obj.GetComponent<Rigidbody2D>().mass * a * h;

        string potencjalna = (EP).ToString("f2");

        ePotText.text = "Energia Potencjalna : " + potencjalna + " J";

        float EK = (obj.GetComponent<Rigidbody2D>().mass * (v*v))/2;

        string kinetyczna = (EK).ToString("f2");

        eKinText.text = "Energia Kinetyczna : " + kinetyczna + " J";

        float m = obj.GetComponent<Rigidbody2D>().mass;

        string masa = (m).ToString("f2");

        masaText.text = "Masa : " + masa + " kg";

        float r = obj.localScale.x;

        string radius = (r).ToString("f2");

        radiusText.text = "Promień : " + radius + " m";

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            isFunctionEnabled = false;
            Debug.Log("trigger");
            WorldBehaviour.GameIsPaused = true;
            Time.timeScale = 0;
        }
    }
}
