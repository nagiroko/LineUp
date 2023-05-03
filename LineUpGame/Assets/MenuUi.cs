using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUi : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator ani;
    int scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  StartAcademy()
    {
        ani.Play("Closing");
        scene = 2;
        StartCoroutine(LoadLevel());
    }

    public void OnTheClock()
    {
        ani.Play("Closing");
        scene = 1;
        StartCoroutine(LoadLevel());
    }

    public void Endgame()
    {
        Application.Quit();
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1);
        ani.Play("Opening");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }

}
