using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  StartAcademy()
    {
        SceneManager.LoadScene(2);
    }

    public void OnTheClock()
    {
        SceneManager.LoadScene(1);
    }

    public void Endgame()
    {
        Application.Quit();
    }
}
