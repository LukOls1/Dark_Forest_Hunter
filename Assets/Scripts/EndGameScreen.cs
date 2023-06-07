using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private PlayerStatsSO playerStats;

    private void Update()
    {
        scoreText.text = "Gold Scored: " + playerStats.EndScore;
    }
}
