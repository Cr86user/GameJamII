using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraOrbit : MonoBehaviour
{
    private Vector2 angle = new Vector2(90 * Mathf.Deg2Rad, 0);



    public Transform follow;
    public float distance;
    public Vector2 sensitivity;



    // Añade esta variable para controlar el bloqueo del cursor
    private bool cursorLocked = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }



    void Update()
    {
        float hor = Input.GetAxis("Mouse X");



        if (hor != 0)
        {
            angle.x += hor * Mathf.Deg2Rad * sensitivity.x;
        }



        float ver = Input.GetAxis("Mouse Y");



        if (ver != 0)
        {
            angle.y += ver * Mathf.Deg2Rad * sensitivity.y;
            angle.y = Mathf.Clamp(angle.y, -80 * Mathf.Deg2Rad, 80 * Mathf.Deg2Rad);
        }



        // Añade un control para bloquear/desbloquear el cursor
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cursorLocked = !cursorLocked;
            Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !cursorLocked;
        }
    }



    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 orbit = new Vector3(
            Mathf.Cos(angle.x) * Mathf.Cos(angle.y),
            -Mathf.Sin(angle.y),
            -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)
        );



        transform.position = follow.position + orbit * distance;
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position);
    }
}