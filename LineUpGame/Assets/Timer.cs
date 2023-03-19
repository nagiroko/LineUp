using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    int seconds;
    int minutes;
    bool time = true;
    void Start()
    {
        StartCoroutine(RecordTime());
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
        Debug.Log("It took you" + minutes.ToString() + "minutes and" + seconds.ToString() + "seconds to match all descriptions with their respective criminals");
    }
}
