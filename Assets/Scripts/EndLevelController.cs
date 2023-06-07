using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelController : MonoBehaviour
{
    [SerializeField]
    private LevelLoader levelLoader;
    [SerializeField]
    private AudioManager audioManager;
    public float nextSceneTime = 3f;
    public void EndLevelScreen()
    {
        nextSceneTime -= Time.deltaTime;
        if(nextSceneTime <= 1)
        {
            audioManager.fadeOut = true;
        }
        if(nextSceneTime <= 0)
        {
            levelLoader.LoadNextLevel("ShopScene");
            gameObject.SetActive(false);
        }
    }
}
