using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI scoreText;
    [SerializeField]
    private PlayerStatsSO playerStats;
    void Update()
    {
        UpdateStats();
    }
    private void UpdateStats()
    {
        hpText.text = "Health: " + playerStats.Life;
        scoreText.text = "Gold: " + playerStats.Score;
    }
}
