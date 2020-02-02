using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Build : MonoBehaviour
{

    public GameObject[] helm;
    public GameObject[] kart;
    public GameObject cinema;
    CinemachineVirtualCamera vcam;

    Vector3 HelmPos;
    private void Awake() {
        vcam = cinema.GetComponent<CinemachineVirtualCamera>();
        Select();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    void Randomize()
    {
        GameObject player = Instantiate(kart[Random.Range(0,2)],transform);
    }
    void Select()
    {
        GameObject player = Instantiate(KartInfo.kart,transform);
        vcam.LookAt = player.transform;
        vcam.Follow = player.transform;
    }
}
