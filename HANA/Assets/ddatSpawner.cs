using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddatSpawner : MonoBehaviour
{
    public GameObject ddatprefab;

    public float spawnRateMin=2f, spawnRateMax=10f;
    float spawnRate, timeAfterSpawn;



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
}
