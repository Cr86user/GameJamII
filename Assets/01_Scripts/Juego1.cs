using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Juego1 : MonoBehaviour
{

    public TextMeshProUGUI txt_jugador1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ActualizarTextoJugador()
    {
        int randomNumber = Random.Range(1, 10);
        txt_jugador1.text = randomNumber.ToString();
    }

}
