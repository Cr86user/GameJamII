using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Juego1 : MonoBehaviour
{
    public TextMeshProUGUI txt_jugador1;
    public TextMeshProUGUI txt_jugador2;
    public TextMeshProUGUI txt_puntajeJugador1;
    public Animator anim;
    public Image lifeTable;
    public Image fondoLife;
    public Image lifePlayer;
    public int vidaMaxima;
    public int vidaActual;
    public int reduccionVida = 3;

    public int puntajeJugador1;
    public int multiplicadorPuntaje = 1;
    public bool Isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        // Inicializa el juego y realiza otras operaciones de inicio si es necesario
        ActualizarTextoJugador();
    }
    public void ActualizarTextoJugador()
    {
        int randomNumber1 = Random.Range(1, 10);
        int randomNumber2 = Random.Range(1, 10);

        // Asegúrate de que los números sean diferentes
        while (randomNumber2 == randomNumber1)
        {
            randomNumber2 = Random.Range(1, 10);
        }

        txt_jugador1.text = randomNumber1.ToString();
        txt_jugador2.text = randomNumber2.ToString();

        if (randomNumber1 > randomNumber2)
        {
            Reducir();
            txt_jugador1.text = randomNumber1.ToString();
            txt_jugador2.text = randomNumber2.ToString();
        }
        else if (randomNumber2 > randomNumber1)
        {
            ReducirJugador();
            txt_jugador1.text = randomNumber1.ToString();
            txt_jugador2.text = randomNumber2.ToString();
        }
        
    }
    

    void Reducir()
    {
        vidaActual -= reduccionVida;
        lifeTable.fillAmount = (float)vidaActual / vidaMaxima;

        if (vidaActual <= 0)
        {
           
            lifeTable.gameObject.SetActive(false);
            fondoLife.gameObject.SetActive(false);

          
            if (vidaActual <= 0)
            {
                puntajeJugador1 += 5 * multiplicadorPuntaje; // Puntaje por intento del jugador 1
            }
        }
        txt_jugador1.text = txt_jugador2.text = "¡Fin del juego!";
        txt_puntajeJugador1.text = "Puntaje: " + puntajeJugador1;
   
    }
    void ReducirJugador()
    {
        vidaActual -= reduccionVida;
        lifePlayer.fillAmount = (float)vidaActual / vidaMaxima;

        if (vidaActual <= 0)
        {

            lifePlayer.gameObject.SetActive(false);
            fondoLife.gameObject.SetActive(false);
            anim.SetBool("Dead", true);
            
        }
        txt_jugador1.text = txt_jugador2.text = "¡Fin del juego!";
        txt_puntajeJugador1.text = "Puntaje: " + puntajeJugador1;
    }

}
