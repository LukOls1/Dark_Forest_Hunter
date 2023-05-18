using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    public void LoadNextLevel(string levelName)
    {
        StartCoroutine("LoadLevel", levelName);
    }
    IEnumerator LoadLevel(string levelName)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
