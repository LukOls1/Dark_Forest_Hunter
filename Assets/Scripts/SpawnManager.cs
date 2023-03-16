using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemiesPrefabs;
    private Vector3 spawnPosition = new Vector3(-12, 1.5f, 0);
    private float spawnDelay = 1;
    private float spawnRate = 2;
    private int waveLenght = 4;
    private int waveCount = 0;
    void Start()
    {
        //InvokeRepeating("SpawnEnemyWave", spawnDelay, spawnRate);
    }

    void Update()
    {

    }
    void SpawnEnemyWave()
    {
        if (waveCount < waveLenght)
        {
            Instantiate(enemiesPrefabs[0], spawnPosition, enemiesPrefabs[0].transform.rotation);
            waveCount += 1;
        }
    }
}
