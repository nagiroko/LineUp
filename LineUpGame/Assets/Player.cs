using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    bool equal = false;
    void Start()
    {
        cam = Camera.main;
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
                    Check(c.CrimNum,d.DescriptNum);
                    if(equal == true)
                    {
                        Destroy(hit.collider.gameObject);
                        Destroy(d.gameObject);
                        DescSpawner spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<DescSpawner>();
                        spawn.Check();
                        equal = false;
                    }
                    else
                    {
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
