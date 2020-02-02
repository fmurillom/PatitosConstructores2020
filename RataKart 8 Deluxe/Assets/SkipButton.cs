using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public string GameScene = "Salad Circuit";
    public void PlayGame(){
        SceneManager.LoadScene(GameScene);
    }
}
