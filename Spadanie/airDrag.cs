using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEditor;
using System.Diagnostics.Contracts;
using UnityEngine.UI;

public class airDrag : MonoBehaviour
{
    public Rigidbody2D objectRig;
    public Transform obj;
    private float customTimer = 0.0f;
    public float customTimeStep = 0.01f;
    float fO, fG, p, rho;
    public float a;
    public float v;
    public float cD;
    public float h;
    public float r;
    public float m;
    public float vLim;
    public Transform transform;
    public Button startSimulation;
    private float startTime;

    float predkosc(float a, float pred, float dt) //Obliczanie Predkosci spadania obiektu
    {
        return pred + a * dt;
    }

    float opor(float gest, float pole, float wskaz, float pred) //Obliczanie Oporu powietrza
    {
        return 0.5f * gest * Math.Abs(pred) * pred * pole * wskaz;
    }
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        a = 9.81f;
        fO = 0f;
        v = 0f;
        cD = 1.05f;
        rho = 1.209f;
        m = objectRig.mass;
        r = obj.localScale.x;
        h = obj.position.y - 1;
        p = r * r * 3.14f;
        fG = m * a * 1f;
        startSimulation.onClick.AddListener(simulationStart);
        
    }
    public void simulationStart(){
        vLim = (float)Math.Sqrt((2 * fG) / (rho * p * cD));
    }
    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
        v = obj.GetComponent<Rigidbody2D>().velocity.magnitude;
        a = v/t;
        h = obj.position.y - 1;


        customTimer += Time.deltaTime;
        if (customTimer >= customTimeStep)
        {
            if(vLim >= v){
                
                objectRig.drag = opor(rho, p, cD, v) / 100f;
            }
            customTimer = 0.0f;
        }
    }
}
