using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;
    public bool fadeOut = false;

    private void Update()
    {
        MusicFade();
    }
    public void playSingleSound(AudioSource fxSound)
    {
        fxSound.Play();
    }
    public void MusicFade ()
    {
        if (!fadeOut)
        {
            music.volume += Time.deltaTime;
        }
        else if (fadeOut)
        {
            music.volume -= Time.deltaTime;
        }
    }
}
