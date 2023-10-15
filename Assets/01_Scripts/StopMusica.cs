using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Musica");

        foreach (GameObject musicObject in musicObjects)
        {
            AudioGame audioComponent = musicObject.GetComponent<AudioGame>();
            if (audioComponent != null)
            {
                audioComponent.Stop();
            }
        }
    }
}
