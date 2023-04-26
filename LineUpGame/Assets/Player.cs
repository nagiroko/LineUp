using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    public bool OnTheClock = false;
    bool equal = false;
    public int score = 0;
    UiBehavior ui;
    void Start()
    {
        cam = Camera.main;
        ui = GameObject.FindGameObjectWithTag("Ui").GetComponent<UiBehavior>();
        if(OnTheClock == true)
        {
            ui.timer.SetActive(true);
        }
        else
        {
            ui.timer.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {      
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2d = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "Criminal")
                {
                    Criminal c = hit.collider.GetComponent<Criminal>();
                    Description d = GameObject.FindGameObjectWithTag("Description").GetComponent<Description>();
                    DescSpawner spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<DescSpawner>();
                    Check(c.CrimNum,d.DescriptNum);
                    if(equal == true)
                    {
                        Destroy(hit.collider.gameObject);
                        Destroy(d.gameObject);
                        if(OnTheClock == false)
                        {
                            spawn.Check();
                        }
                        else
                        {
                            score += 1;
                            spawn.clean();
                            spawn.WorkLoad();
                            ui.TimeReset();

                        }
                        equal = false;
                    }
                    else
                    {
                        if(OnTheClock == true)
                        {
                            spawn.clean();
                            ui.timer.SetActive(false);
                            ui.score(score, 0, true);
                        }
                        Debug.Log("Not Eqal");
                    }
                }
            }
        }
    }

    void Check(int crim,int des)
    {
        if(crim == des)
        {
            equal = true;
        }

    }

}
