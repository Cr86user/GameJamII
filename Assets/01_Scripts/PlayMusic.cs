using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Musica");

        foreach (GameObject musicObject in musicObjects)
        {
            Audio1 audioComponent = musicObject.GetComponent<Audio1>();
            if (audioComponent != null)
            {
                audioComponent.PlayMusic();
            }
        }
    }
}
