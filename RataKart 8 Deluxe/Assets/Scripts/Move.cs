using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;
    public float horizontalMove;
    Rigidbody rb;
    public float speed;
    Quaternion rotatePos;
    Vector3 movePos;
    public float rotationSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        if (Input.touchCount > 0){
            float width = Screen.width;
            Touch touch = Input.GetTouch(0);
            horizontalMove = (touch.position.x - width/2)/(width/2);
            transform.Translate(new Vector3(),Space.Self);
        }
        else{
            horizontalMove = 0;
            agent.destination = goal.position;
        }
        rotatePos = Quaternion.Euler(0.0f, horizontalMove * rotationSpeed, 0.0f);
        rb.MoveRotation(transform.rotation * rotatePos);
        
    }
}
