using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeChanger : MonoBehaviour
{
    public GameObject Object; 
    public Dropdown Ksztalt;
    public airDrag airDrag;

    private void Start()
    {
        Object.GetComponent<SpriteRenderer>().enabled = true;
        Object.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SquareSprite");
        airDrag.cD = 1.05f;
        Ksztalt.onValueChanged.AddListener(ChangeShape);
        float value = airDrag.cD;
    }

    void ChangeShape(int index)
    {
        // Sprawdzamy, która opcja została wybrana
        switch (index)
        {
            case 0:
                // Kwadrat
                Object.GetComponent<SpriteRenderer>().enabled = true;
                Object.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SquareSprite");
                airDrag.cD = 1.05f;
                break;
                
            case 1:
                // Okrąg
                Object.GetComponent<SpriteRenderer>().enabled = true;
                Object.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("CircleSprite");
                airDrag.cD = 0.47f;
                break;
            case 2:
                // kropla
                Object.GetComponent<SpriteRenderer>().enabled = true;
                Object.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TearSprite");
                airDrag.cD = 0.04f;
                break;
            default:
                // Domyślnie ustawiamy kwadrat
                Object.GetComponent<SpriteRenderer>().enabled = true;
                Object.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SquareSprite");
                airDrag.cD = 1.05f;
                break;
        }
    }
}
