using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{
    [SerializeField] 
    private PlayerStatsSO playerStats;
    [SerializeField]
    private WavesDataSO wavesData;
    public void StartGame ()
    {
        wavesData.WavesNumber = wavesData.StartWaves;
        wavesData.EnemyNumber = wavesData.StartEnemy;
        playerStats.Life = 4;
        playerStats.Score = 0;
        playerStats.EndScore = 0;
        playerStats.AtkSpeed = 1.0f;
        SceneManager.LoadScene("Main Scene", LoadSceneMode.Single);
    }
}
