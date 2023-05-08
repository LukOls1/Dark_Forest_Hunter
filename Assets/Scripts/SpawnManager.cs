using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private NextWaveController nextwaveController;
    private EndLevelController endLevelController;
    private int enemyDeaths;
    private int enemiesOnMap;
    private Vector3[] spawnPositions = { new Vector3(21.5f, 1.5f, 0), new Vector3(-12, 1.5f, 0) } ;
    private int randomizePosition;
    //private Vector3 spawnPosition = new Vector3(-12, 1.5f, 0); 
    private int spawnRate = 2;
    private float timeToNextEnemy = 0;
    
    public int enemyWaves = 2;
    public GameObject nextWaveScreen;
    public GameObject endLevelScreen;
    public List<GameObject> enemiesPrefabs;
    public List<GameObject> deadEnemies;
    public int enemyLenght = 1;
    public int enemyCount = 0;
    public bool wavesDownCounted = false;


    void Start()
    {

    }

    void Update()
    {
        enemyDeaths = deadEnemies.Count;
        if (enemyWaves > 0)
        {
            SpawnEnemyWave();
        }
        if (enemyWaves <= 0)
        {
            endLevelScreen.SetActive(true);
            endLevelController = GameObject.Find("EndLevelScreen").GetComponent<EndLevelController>();
            endLevelController.EndLevelScreen();
        }
    }
    void SpawnEnemyWave()
    {
        if (enemyCount < enemyLenght && Time.time > timeToNextEnemy)
        {
            randomizePosition = Random.Range(0, 2);
            Instantiate(enemiesPrefabs[0], spawnPositions[randomizePosition], enemiesPrefabs[0].transform.rotation);
            enemyCount += 1;
            timeToNextEnemy = Time.time + spawnRate;           
        }
        if (enemyCount == enemyLenght && enemyDeaths == enemyCount)
        {
            if (enemyWaves > 0 && !wavesDownCounted)
            {
                enemyWaves -= 1;
                wavesDownCounted = true;
            }
            if (enemyWaves > 0 && wavesDownCounted)
            {
                nextWaveScreen.SetActive(true);
                nextwaveController = nextWaveScreen.GetComponent<NextWaveController>();
                nextwaveController.NextWaveScreen(enemyWaves);
            }

        }
    }
}
