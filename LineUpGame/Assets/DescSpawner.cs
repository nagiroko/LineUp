using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class DescSpawner : MonoBehaviour
{
    public GameObject[] Descriptions;
    private List<int> DescriptionNumbers = new List<int>();
    private List<int> CrimNumbers = new List<int>();
    private int CrimLength = 4;
    Player player;
    Timer time;
    public Vector3 spawnpoint;

    public Vector3[] CrimSpawns;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Player>();
        time = GetComponent<Timer>();
        if(player.OnTheClock == false)
        {
            SpawnCrims();
            MakeList();
            Check();
        }
        else
        {
            WorkLoad();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCrims()
    {
        EnemySpawnHolder holder = GameObject.FindGameObjectWithTag("Holder").GetComponent<EnemySpawnHolder>();
        int SpawnCount = 0;
        while(CrimNumbers.Count != 20)
        {
            int Qnum = Random.Range(0, holder.criminals.Length);
            if(CrimNumbers.Contains(Qnum) == false)
            {
                CrimNumbers.Add(Qnum);
            }
        }
        while(SpawnCount != 20)
        {
            Instantiate(holder.criminals[CrimNumbers[SpawnCount]], CrimSpawns[SpawnCount], Quaternion.identity);
            SpawnCount += 1;
        }
    
    }
    
    void MakeList()
    {
        while(DescriptionNumbers.Count != 20)
        {
            int Qnum = Random.Range(0, 20);
            if(DescriptionNumbers.Contains(CrimNumbers[Qnum]) == false)
            {
                DescriptionNumbers.Add(CrimNumbers[Qnum]);
            }
        }
    }

    public void Check()
    {
        if(DescriptionNumbers.Count == 0)
        {
            time.StopTime();
        }
        else
        {
            Instantiate(Descriptions[DescriptionNumbers[0]], spawnpoint, Quaternion.identity);
            DescriptionNumbers.RemoveAt(0);
            Debug.Log(DescriptionNumbers[0]);
        }
    }

    public void clean()
    {
        GameObject[] crims = GameObject.FindGameObjectsWithTag("Criminal");
        CrimNumbers = new List<int>();
        foreach (GameObject crim in crims)
        {
            Destroy(crim);
        }
        CrimNumbers = new List<int>();
        CrimLength += 4;
        Destroy(GameObject.FindGameObjectWithTag("Description"));
    }

    public void WorkLoad()
    {
        EnemySpawnHolder holder = GameObject.FindGameObjectWithTag("Holder").GetComponent<EnemySpawnHolder>();
        int SpawnCount = 0;
        if (CrimLength >= 20)
        {
            CrimLength = 20;
        }
        while (CrimNumbers.Count != CrimLength)
        {
            int Qnum = Random.Range(0, holder.criminals.Length);
            if (CrimNumbers.Contains(Qnum) == false)
            {
                CrimNumbers.Add(Qnum);
            }
        }
        while (SpawnCount != CrimLength)
        {
            Instantiate(holder.criminals[CrimNumbers[SpawnCount]], CrimSpawns[SpawnCount], Quaternion.identity);
            SpawnCount += 1;
        }
        int num = Random.Range(0, CrimLength);
        Instantiate(Descriptions[CrimNumbers[num]], spawnpoint, Quaternion.identity);
    }

}
