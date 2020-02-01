using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string GameScene = "Car Select";
    public void PlayGame(){

        SceneManager.LoadScene(GameScene);

    }
}
