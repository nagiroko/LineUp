using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour
{
    int seconds;
    int minutes;
    bool time = true;
    UiBehavior ui;
    void Start()
    {
        StartCoroutine(RecordTime());
        ui = GameObject.FindGameObjectWithTag("Ui").GetComponent<UiBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopTime()
    {
        time = false;
    }

    IEnumerator RecordTime()
    {
        while(time == true)
        {
            seconds += 1;
            if(seconds == 60)
            {
                minutes += 1;
                seconds = 0;
            }
            yield return new WaitForSeconds(1f);
        }
        ui.score(minutes, seconds);
    }
}
