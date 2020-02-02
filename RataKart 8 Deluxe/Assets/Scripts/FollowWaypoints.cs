// FollowWaypoints.cs
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;


public class FollowWaypoints : MonoBehaviour
{

    private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public string phaseDisplayText = "";
    private Touch theTouch;

    private GameObject waypoints;

    private GameObject[] cubes;



    void Start()
    {

        points  = new Transform[32];
        
        waypoints = GameObject.Find("Cube");

        points[0] = waypoints.GetComponent<Transform>();

        for (int i = 1; i < 32; i++)
        {
            string name = "Cube (" + i.ToString() + ")";
            waypoints = GameObject.Find(name);

            points[i] = waypoints.GetComponent<Transform>();

        }

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
}