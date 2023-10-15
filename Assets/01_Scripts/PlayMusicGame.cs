using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("MusicaGame");

        foreach (GameObject musicObject in musicObjects)
        {
            AudioGame audioComponent = musicObject.GetComponent<AudioGame>();
            if (audioComponent != null)
            {
                audioComponent.PlayMusic();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
