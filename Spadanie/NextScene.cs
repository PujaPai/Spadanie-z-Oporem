using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public Button Next;
    void Start(){
        Next.onClick.AddListener(LoadNext);
    }
    public void LoadNext()
    {
        SceneManager.LoadScene("Symulacja");
    }
}
