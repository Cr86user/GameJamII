using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCañaman : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;
    public bool Drink;
    public bool avance;
    public float fastDrink = 10f;

    bool isDrinking = false;

    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        //anim.SetBool("tomar", false);

        Drinka();
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            if (isDrinking)
            {
                anim.SetBool("tomar", true);
                isDrinking = false;
            }
            else
            {
                anim.SetBool("tomar", false);
                isDrinking = true;
            }
        }*/

        

        //anim.SetBool("tomar", false);

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
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidad);
        }


        if (avance)
        {
            rb.velocity = transform.forward * fastDrink;
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
