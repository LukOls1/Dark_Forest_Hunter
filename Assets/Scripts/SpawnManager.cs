using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemiesPrefabs;
    public int enemyDeaths;
    private int enemiesOnMap;
    private Vector3 spawnPosition = new Vector3(-12, 1.5f, 0);
    private int enemyLenght = 4;
    private int enemyCount = 0;
    private int spawnRate = 2;
    private float timeToNextEnemy = 0;
    private int enemyWaves = 3;

    void Start()
    {

    }

    void Update()
    {
        enemiesOnMap = FindObjectsOfType<Enemy>().Length;
        if (enemyWaves > 0)
        {
            SpawnEnemyWave();
        }
    }
    void SpawnEnemyWave()
    {
        if (enemyCount < enemyLenght && Time.time > timeToNextEnemy)
        {                      
            Instantiate(enemiesPrefabs[0], spawnPosition, enemiesPrefabs[0].transform.rotation);
            enemyCount += 1;
            timeToNextEnemy = Time.time + spawnRate;
            
        }
        else if (enemyCount == enemyLenght && enemyCount == enemyDeaths)
        {
            enemyWaves -= 1;
            Debug.Log("koniec fali, zmniejszamy liczbe pozosta³ych do przejœcia");
        }
    }
}
