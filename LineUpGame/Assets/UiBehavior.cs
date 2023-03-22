using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class UiBehavior : MonoBehaviour
{
    public TMP_Text Score;
    public GameObject UiHolder;
    void Start()
    {
        UiHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void score(int min, int sec)
    {
        
        Score.text = "It took you " + min.ToString() + " minutes and " + sec.ToString() + " seconds to match all descriptions with their respective criminals";
        UiHolder.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
