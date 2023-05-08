using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextWaveController : MonoBehaviour
{
    private float timeLeft = 5f;
    private SpawnManager spawnManager;
    public TextMeshProUGUI countDownText;
    public TextMeshProUGUI wavesLeftText;
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    void Update()
    {

    }
    public void NextWaveScreen(int waves)
    {
        wavesLeftText.text = "Waves Left: " + waves;

        timeLeft -= Time.deltaTime;
        countDownText.text = "Next in ... " + Mathf.CeilToInt(timeLeft).ToString();
        if (timeLeft < 0 && timeLeft > -1)
        {
            countDownText.text = "FIGHT";
        }
        if (timeLeft < -1)
        {
            spawnManager.enemyCount = 0;
            spawnManager.enemyLenght += 2;
            spawnManager.deadEnemies.Clear();
            spawnManager.wavesDownCounted = false;
            timeLeft = 5f;
            gameObject.SetActive(false);
        }
    }
}
