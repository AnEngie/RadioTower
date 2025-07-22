using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    private float nextTramAppearance;
    public GameObject tram;
    public float minTramTime;
    public float maxTramTime;
    public GameObject[] spawners;
    public float spawnOffsetX = 5f;

    // Start is called before the first frame update
    void Start()
    {
        RandomTime(minTramTime, maxTramTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTramAppearance > 0 && tram.activeSelf == false)
        {
            nextTramAppearance--;
        }
        else if (nextTramAppearance <= 0 && tram.activeSelf == false)
        {
            SpawnInVehicle();
            RandomTime(minTramTime, maxTramTime);
        }
    }

    private void RandomTime(float minTime, float maxTime)
    {
        nextTramAppearance = Random.Range(minTime, maxTime);
    }

    void SpawnInVehicle()
    {
        var spawner = Random.Range(0, spawners.Length);

        Vector3 spawnerPos = spawners[spawner].transform.position;

        switch (spawner)
        {
            case 0:
                tram.transform.position = new Vector3(spawnerPos.x + spawnOffsetX, tram.transform.position.y, tram.transform.position.z);
                break;
            case 1:
                tram.transform.position = new Vector3(spawnerPos.x - spawnOffsetX, tram.transform.position.y, tram.transform.position.z);
                break;
        }

        tram.SetActive(true);
    }
}
