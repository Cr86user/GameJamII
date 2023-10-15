using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGame : MonoBehaviour
{
    private static AudioSource Audio;

    private void Awake()
    {
        if (Audio != null)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Audio = GetComponent<AudioSource>();
        }
    }

    public void PlayMusic()
    {
        if (Audio.isPlaying) return;
        Audio.Play();
    }

    public void Stop()
    {
        Audio.Stop();
    }


}
