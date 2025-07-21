using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private float nextVehicle;
    public GameObject tram;
    public float minTramTime;
    public float maxTramTime;

    // Start is called before the first frame update
    void Start()
    {
        RandomTime(minTramTime, maxTramTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextVehicle >= 0 && tram.activeSelf == false)
        {
            nextVehicle--;
        }
        else
        {
            RandomTime(minTramTime, maxTramTime);
            SpawnInVehicle();
        }
    }

    private void RandomTime(float minTime, float maxTime)
    {
        nextVehicle = Random.Range(minTime, maxTime);
    }

    void SpawnInVehicle()
    {
        tram.SetActive(true);
    }
}
