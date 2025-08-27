using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private float nextTramAppearance;
    private float nextNpcAppearance;
    public GameObject tram;
    public float minTramTime;
    public float maxTramTime;
    public GameObject[] spawners;
    public float minNpcTime;
    public float maxNpcTime;
    public GameObject[] backgroundNpc;
    public float spawnOffsetX = 5f;

    void Start()
    {
        nextTramAppearance = Random.Range(minTramTime, maxTramTime);
        nextNpcAppearance = Random.Range(minNpcTime, maxNpcTime);
    }

    void FixedUpdate()
    {
        if (nextTramAppearance > 0 && tram.activeSelf == false)
        {
            nextTramAppearance--;
        }
        else if (nextTramAppearance <= 0 && tram.activeSelf == false)
        {
            SpawnInVehicle();
            nextTramAppearance = Random.Range(minTramTime, maxTramTime);
        }

        if (nextNpcAppearance > 0)
        {
            nextNpcAppearance--;
        }
        else if (nextNpcAppearance <= 0)
        {
            SpawnInPerson();
            nextNpcAppearance = Random.Range(minNpcTime, maxNpcTime);
        }
    }

    private float RandomTime(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }

    void SpawnInVehicle()
    {
        var spawner = Random.Range(0, spawners.Length);
        Vector3 spawnerPos = spawners[spawner].transform.position;

        switch (spawner)
        {
            case 0:
                tram.transform.position = new Vector3(spawnerPos.x - spawnOffsetX, tram.transform.position.y, tram.transform.position.z);
                break;
            case 1:
                tram.transform.position = new Vector3(spawnerPos.x + spawnOffsetX, tram.transform.position.y, tram.transform.position.z);
                break;
        }

        tram.SetActive(true);
    }

    void SpawnInPerson()
    {
        var chosenNpc = Random.Range(0, backgroundNpc.Length);

        var chosenNpcType = backgroundNpc[chosenNpc];

        if (!chosenNpcType.activeSelf)
        {
            var spawner = Random.Range(0, spawners.Length);
            Vector3 spawnerPos = spawners[spawner].transform.position;

            switch (spawner)
            {
                case 0:
                    chosenNpcType.transform.position = new Vector3(spawnerPos.x - spawnOffsetX, chosenNpcType.transform.position.y, chosenNpcType.transform.position.z);
                    break;
                case 1:
                    chosenNpcType.transform.position = new Vector3(spawnerPos.x + spawnOffsetX, chosenNpcType.transform.position.y, chosenNpcType.transform.position.z);
                    break;
            }

            chosenNpcType.SetActive(true);
        }
    }
}
