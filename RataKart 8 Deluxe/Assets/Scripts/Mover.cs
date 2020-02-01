using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float horizontalMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0){
            float width = Screen.width;
            Touch touch = Input.GetTouch(0);
            horizontalMove = (touch.position.x - width/2)/(width/2);
            transform.Translate(new Vector3(),Space.Self);
        }
        else{
            horizontalMove = 0;
        }
    }
}
