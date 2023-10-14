using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerCañaman : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float velocidadRotacion = 200.0f;
    public Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;
    public bool Drink;
    public bool avance;
    public float fastDrink = 10f;

    public bool isSitting = false;

    public Transform chair;
    public float detectionDistance = 200.0f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public Vector3 sitOffset; // Offset de posición para que el personaje se siente en relación con la silla.
    public Quaternion sitRotation; // Rotación para el personaje cuando se sienta en la silla.


    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        isSitting = false;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }
    void FixedUpdate()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        Drinka();
        //SitDown();
        Sit();

      

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jump",true);
                rb.AddForce(new Vector3 (0, fuerzaSalto, 0),ForceMode.Impulse);
            }
            anim.SetBool("Toco",true);
        }
        else
        {
            EstoyCayendo();
        }

    }

    void Drinka()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //anim.SetBool("tomar", true);
            anim.SetTrigger("Drink");

            //Drink = true;
        }
    }

    void Movement()
    {
        if (!Drink)
        {
            transform.Rotate(0, x * Time.deltaTime * -1 * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidad);
        }

        if (avance)
        {
            rb.velocity = transform.forward * fastDrink;
        }
    }

    /*public void SitDown()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isSitting)
            {
                anim.SetBool("Sit", false);
                isSitting = false;
            }
            else
            {
                Collider[] chairs = Physics.OverlapSphere(transform.position, 1.0f);
                foreach (Collider chair in chairs)
                {
                    if (chair.CompareTag("Chair"))
                    {
                        anim.SetBool("Sit", true);
                        isSitting = true;
                        break;
                    }
                }
            }
        }
    }*/

    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Chair"))
        {
            if (!isSitting)
            {
                // Cambiar la animación y el estado del personaje a "sentado"
                anim.SetBool("Sit", true);
                isSitting = true;

                // Cambiar la posición y rotación del personaje para que esté sentado en la silla
                Vector3 chairPosition = collision.transform.position;
                Quaternion chairRotation = collision.transform.rotation;
                transform.position = chairPosition;
                transform.rotation = chairRotation;
            }
        }
    }*/

    void Sit()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isSitting)
            {
                // Guarda la posición y rotación originales
                originalPosition = transform.position;
                originalRotation = transform.rotation;

                // Calcula la posición del personaje para que se siente en la silla.
                Vector3 chairPosition = transform.position + sitOffset;

                // Aplica una rotación de 180 grados alrededor del eje X para que el personaje esté boca abajo.
                Quaternion chairRotation = Quaternion.Euler(180.0f, 0.0f, 0.0f);

                // Cambia la animación y el estado del personaje a "sentado"
                anim.SetBool("Sit", true);
                isSitting = true;

                // Cambia la posición y rotación del personaje para que esté sentado en la silla
                transform.position = chairPosition;
                transform.rotation = chairRotation;
            }
            else
            {
                // Cambia la animación y el estado del personaje a "de pie"
                anim.SetBool("Sit", false);
                isSitting = false;

                // Restaura la posición y rotación originales del personaje
                transform.position = originalPosition;
                transform.rotation = originalRotation;
            }
        }

    }

    void ChangeScene()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("eeeeeeedetectada");

            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionDistance);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Table"))
                {
                    Debug.Log("Mesa detectada");
                    SceneManager.LoadScene("2Scene");
                    break; // Sal del bucle si se encuentra una mesa.
                }
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            SceneManager.LoadScene("2Scene");
        }
        if (other.CompareTag("Table2"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }





    public void EstoyCayendo()
    {
        //anim.SetBool("Toco", false);
        //anim.SetBool("Jump", false);
    }

    public void NotDrink()
    {
        Drink = false;

    }

    public void Avance()
    {

        avance = true;
    }

    public void NoAvance()
    {

        avance = false;
    }

}
