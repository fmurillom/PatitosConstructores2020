using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour
{

    private float mouseLife = 100.0f;
    private float cartLife = 100.0f;
    private float wheelLife = 100.0f;
    public Transform Head;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "KEZO")
        {
            mouseLife = mouseLife + 5.0f;
        }
        else if (other.transform.tag == "Bandita")
        {
            wheelLife = wheelLife + 5.0f;
        }
        else if (other.transform.tag == "Lata")
        {
            cartLife = cartLife + 5.0f;
        }
        else
        {
            Vector3 hit = other.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);
            //Down
            if (!Mathf.Approximately(angle, 0))
            {

                float random = Mathf.Round(Random.Range(0, 2));

                Debug.Log("Pene");
                Debug.Log(mouseLife);
                Debug.Log(cartLife);
                Debug.Log(wheelLife);

                if (random == 0)
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
}
