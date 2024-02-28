using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeResizer : MonoBehaviour
{
    public airDrag airDragS;
    public GameObject Object;    
    public Transform obj;    
    public InputField Ustaw_Promien;
    public InputField Ustaw_Mase;
    public InputField Ustaw_Wysokosc;
    public float min = 0.1f;
    public float max = 5f;    

    private void Start()
    {
        Ustaw_Promien.onEndEdit.AddListener(ResizeShape);
        Ustaw_Mase.onEndEdit.AddListener(ResizeMass);
        Ustaw_Wysokosc.onEndEdit.AddListener(ResizeHeight);
    }

    void ResizeShape(string newSize)
    {
        if (float.TryParse(newSize, out float sizeValue))
        {
            sizeValue = Mathf.Clamp(sizeValue, min, max);

            Object.transform.localScale = new Vector3(sizeValue, sizeValue, 1f);

            float value = airDragS.r;
            airDragS.r = obj.localScale.x;
        }
        else
        {
            Debug.LogError("Nieprawidłowa wartość wielkości: " + newSize);
        }
    }
    void ResizeMass(string newMass)
    {
        if (float.TryParse(newMass, out float masa))
        {
            Object.GetComponent<Rigidbody2D>().mass = masa;

            float value = airDragS.m;
            airDragS.m = masa;
        }
        else
        {
            Debug.LogError("Nieprawidłowa wartość masy: " + newMass);
        }
    }
    void ResizeHeight(string newHeight)
    {
        if (float.TryParse(newHeight, out float height))
        {
            Vector3 nowaPozycja = obj.position;
            nowaPozycja.y = height + 1;
            obj.position = nowaPozycja;
            float value = airDragS.h;
            airDragS.h = obj.position.y - 1;
        }
        else
        {
            Debug.LogError("Nieprawidłowa wartość wysokości: " + newHeight);
        }
    }
}

