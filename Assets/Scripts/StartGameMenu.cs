using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameMenu : MonoBehaviour
{
    private GameObject startMenu;
    private PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        startMenu = GameObject.Find("StartGameMenu");
        Time.timeScale = 0;
    }

    void Update()
    {
        
    }
    public void StartGame ()
    {
        Time.timeScale = 1;
        startMenu.SetActive(false);
        playerController.isGameActive = true;
    }
}
