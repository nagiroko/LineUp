using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class DescSpawner : MonoBehaviour
{
    public GameObject[] Descriptions;
    private List<int> DescriptionNumbers = new List<int>();
    public Vector3 spawnpoint;
 
    void Start()
    {
        MakeList();
        Check();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeList()
    {
        while(DescriptionNumbers.Count != 20)
        {
            int Qnum = Random.Range(0, Descriptions.Length);
            if(DescriptionNumbers.Contains(Qnum) == false)
            {
                DescriptionNumbers.Add(Qnum);
            }
        }
    }

    public void Check()
    {
        if(DescriptionNumbers.Count == 0)
        {
            Debug.Log("You win");
        }
        else
        {
            Instantiate(Descriptions[DescriptionNumbers[0]], spawnpoint, Quaternion.identity);
            DescriptionNumbers.RemoveAt(0);
            Debug.Log(DescriptionNumbers[0]);
        }
    }

}
