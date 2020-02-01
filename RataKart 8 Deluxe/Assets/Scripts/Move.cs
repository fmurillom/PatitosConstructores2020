using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Velocidad de moviemiento de personaje
    public float speed = 1;
    //Nivel
    int level = 0;
    //Rigidbody
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        AxisInput();
    }

    //Teclado
    //Otra Manera de Hacerlo
    void AxisInput()
    {
        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + Vector3.forward * speed);
        }
        //Back
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + Vector3.back * speed);
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up));
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + Vector3.right * speed);
        }
    }
}
