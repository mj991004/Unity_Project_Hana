using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddatSpawner : MonoBehaviour
{
    public GameObject ddatprefab;

    public float spawnRateMin=5f, spawnRateMax=10f;
    float spawnRate, timeAfterSpawn;
    int phase = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn>=spawnRate)
        {
            GameObject t = Instantiate(ddatprefab,transform);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            timeAfterSpawn = 0f;
        }
    }
    public int addPhase()
    {
        if (phase < 5)
        {
            phase++;
            spawnRateMin = 6 - phase;
            spawnRateMax = 2 * spawnRateMin;
        }
        return phase;
    }
}
