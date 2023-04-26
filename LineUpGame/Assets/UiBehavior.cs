using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class UiBehavior : MonoBehaviour
{
    public TMP_Text Score;
    public GameObject UiHolder;
    public GameObject timer;
    public TMP_Text Timer;
    Player player;
    float currentime = 0f;
    float startingtime = 5f;
    DescSpawner spawn;
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<DescSpawner>();
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        currentime = startingtime;
        UiHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.OnTheClock == true)
        {
            currentime -= 1 * Time.deltaTime;
            if(currentime <= 0)
            {
                currentime = 0;
            }
            Timer.text = currentime.ToString("0");
            if (currentime == 0)
            {
                spawn.clean();
                timer.SetActive(false);
                score(player.score, 0, player.OnTheClock);
            }
            
        }
    }

    public void score(int min, int sec, bool OnTheClock)
    {
        if(OnTheClock == false)
        {
            Score.text = "It took you " + min.ToString() + " minutes and " + sec.ToString() + " seconds to match all descriptions with their respective criminals";
            UiHolder.SetActive(true);
        }
        else
        {
            Score.text = "You were able to catch " + min.ToString() + " criminals this shift";
            UiHolder.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TimeReset()
    {
        currentime = startingtime;
    }

    
    public void Quit()
    {
        SceneManager.LoadScene(0);

    }
}
