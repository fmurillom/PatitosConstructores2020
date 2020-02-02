// FollowWaypoints.cs
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;


public class FollowWaypoints : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public string phaseDisplayText = "";
    private Touch theTouch;

    private float mouseLife = 100.0f;
    private float cartLife = 100.0f;
    private float wheelLife = 100.0f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        agent.destination = points[destPoint].position;

        agent.updateRotation = true;

    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up

        destPoint = destPoint + 1;

        if ( (destPoint + 1) == points.Length)
        {
            destPoint = 0;
        }

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.

    }


    void FixedUpdate()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
        //GotoNextPoint();

        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);            

            if(theTouch.phase == TouchPhase.Stationary)
            {
                if(theTouch.position.x >= 600)
                {
                    transform.Translate(Vector3.right * 10 * Time.deltaTime);
                }
                if (theTouch.position.x <= 600)
                {
                    transform.Translate(Vector3.left * 10 * Time.deltaTime);
                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Waypoints")
        {
            GotoNextPoint();
        }

        if (other.tag == "Goal")
        {
            destPoint = 0;
            Debug.Log("Reset");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        Vector3 hit = collision.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.up);
        //Down
        if (!Mathf.Approximately(angle, 0))
        {

            float random = Mathf.Round(Random.Range(0, 2));

             Debug.Log("Pene");
             Debug.Log(mouseLife);
             Debug.Log(cartLife);
             Debug.Log(wheelLife);

            if(random == 0)
            {
                mouseLife = mouseLife - 5.0f;
            }
            if (random == 1)
            {
                cartLife = cartLife - 5.0f;
            }
            if (random == 2)
            {
                wheelLife = wheelLife - 5.0f;
            }
        }

        
    }
}