using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start(){
        Time.timeScale = 1.0f;
    }
    public void pause(){
        Time.timeScale = 0.0f;
    }
}
