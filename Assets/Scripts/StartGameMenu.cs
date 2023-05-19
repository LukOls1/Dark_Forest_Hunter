using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{
    //private GameObject startMenu;
    //private PlayerController playerController;
    [SerializeField] 
    private PlayerStatsSO playerStats;
    [SerializeField]
    private WavesDataSO wavesData;
    //private bool firstSceneStart = true;

    private void Awake()
    {
        wavesData.WavesNumber = wavesData.StartWaves;
        wavesData.EnemyNumber = wavesData.StartEnemy;
        playerStats.Life = 4;
        playerStats.Score = 0;
        playerStats.AtkSpeed = 1.5f;

    }
    void Start()
    {
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
       // startMenu = GameObject.Find("StartGameMenu");
        //Time.timeScale = 0;
    }

    void Update()
    {
        
    }
    public void StartGame ()
    {
        //playerController.isGameActive = true;
        // Time.timeScale = 1;
        //startMenu.SetActive(false);
        SceneManager.LoadScene("Main Scene", LoadSceneMode.Single);

    }
}
