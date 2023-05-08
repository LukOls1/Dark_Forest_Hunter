using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelController : MonoBehaviour
{
    private float nextSceneTime = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void EndLevelScreen()
    {
        nextSceneTime -= Time.deltaTime;
        if(nextSceneTime <= 0)
        {
            SceneManager.LoadScene("ShopScene", LoadSceneMode.Single);
            gameObject.SetActive(false);
        }
    }
}
