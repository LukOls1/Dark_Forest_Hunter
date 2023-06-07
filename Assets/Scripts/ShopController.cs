using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private PlayerStatsSO playerStats;
    [SerializeField]
    private WavesDataSO wavesData;
    private AudioManager audioManager;
    private AudioSource clickSound;
    private bool atkSpeedBought = false;
    public LevelLoader levelLoader;
    public Button buyAttack;
    public Button buyHP;
    public Button nextDayButton;
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        clickSound = GameObject.Find("AudioManager").GetComponent<AudioSource>();

    }

    void Update()
    {
        if (atkSpeedBought)
        {
            buyAttack.gameObject.SetActive(false);
        }
        if (playerStats.Life == 4)
        {
            buyHP.gameObject.SetActive(false);
        }
    }
    public void BuyAttackSpeed()
    {
        if (atkSpeedBought == false && playerStats.Score >= 200)
        {
            audioManager.playSingleSound(clickSound);
            playerStats.AtkSpeed /= 2;
            playerStats.Score -= 200;
            atkSpeedBought = true;
            Debug.Log(playerStats.AtkSpeed.ToString());
        }
    }
    public void BuyHP()
    {
        if (playerStats.Score >= 50 && playerStats.Life < 4)
        {
            audioManager.playSingleSound(clickSound);
            playerStats.Life += 1;
            playerStats.Score -= 50;
            Debug.Log(playerStats.Life.ToString());
        }
    }
    public void NextDay()
    {
        audioManager.playSingleSound(clickSound);
        audioManager.fadeOut = true;
        wavesData.WavesNumber = wavesData.StartWaves + 1;
        wavesData.EnemyNumber += 1;
        levelLoader.LoadNextLevel("Main Scene");
    }

}
