using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string GameScene = "Car Select";
    public void PlayGame(){
        SceneManager.LoadScene(GameScene);
    }

    public void MainMenu(){
        SceneManager.LoadScene("Menu");
    }
}
