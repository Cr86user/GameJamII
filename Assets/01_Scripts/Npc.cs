using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;
    public GameObject target;

    void Start()
    {
        anim = GetComponent<Animator>();
       //target = GameObject.Find("Player");
    }

    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            cronometro += 1 * Time.deltaTime;
            if (cronometro >=4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
                case 1:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                anim.SetBool("walk", true);
                break;
            }
        }
        else
        {
            var search = target.transform.position - transform.position;
            search.y = 0;
            var rotation = Quaternion.LookRotation(search);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            anim.SetBool("walk", false);

            anim.SetBool("walk", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);

        }
    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }
}
