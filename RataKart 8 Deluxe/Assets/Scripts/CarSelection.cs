using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    
    public GameObject BlueHelm;
    public GameObject GreenHelm;
    public GameObject RedHelm;
    public GameObject Cart;
    public GameObject Wagon;
    public GameObject Chariot;

    private int CartInt = 1;
    private int HelmInt = 1;

    public CarSelection(){
        KartInfo.helm = BlueHelm;
        KartInfo.kart = Cart;
    }

    public void NextHelm(){
        switch (HelmInt)
        {
            case 1:
                BlueHelm.SetActive(false);
                GreenHelm.SetActive(true);
                HelmInt++;
                KartInfo.helm = GreenHelm;
                break;
            case 2:
                GreenHelm.SetActive(false);
                RedHelm.SetActive(true);
                HelmInt++;
                KartInfo.helm = RedHelm;
                break;
            case 3:
                RedHelm.SetActive(false);
                BlueHelm.SetActive(true);
                HelmInt = 1;
                KartInfo.helm = BlueHelm;
                break;
            default:
                break;
        }
    }

    public void PrevHelm(){
        switch (HelmInt)
        {
            case 1:
                BlueHelm.SetActive(false);
                RedHelm.SetActive(true);
                HelmInt = 3;
                KartInfo.helm = RedHelm;
                break;
            case 2:
                GreenHelm.SetActive(false);
                BlueHelm.SetActive(true);
                HelmInt--;
                KartInfo.helm = BlueHelm;
                break;
            case 3:
                RedHelm.SetActive(false);
                GreenHelm.SetActive(true);
                HelmInt--;
                KartInfo.helm = GreenHelm;
                break;
            default:
                break;
        }
    }

    public void NextCart(){
        switch (CartInt)
        {
            case 1:
                Cart.SetActive(false);
                Wagon.SetActive(true);
                CartInt++;
                KartInfo.kart = Wagon;
                break;
            case 2:
                Wagon.SetActive(false);
                Chariot.SetActive(true);
                CartInt++;
                KartInfo.kart = Chariot;
                break;
            case 3:
                Chariot.SetActive(false);
                Cart.SetActive(true);
                CartInt = 1;
                KartInfo.kart = Cart;
                break;
            default:
                break;
        }
    }

    public void PrevCart(){
        switch (CartInt)
        {
            case 1:
                Cart.SetActive(false);
                Chariot.SetActive(true);
                CartInt = 3;
                KartInfo.kart = Chariot;
                break;
            case 2:
                Wagon.SetActive(false);
                Cart.SetActive(true);
                CartInt--;
                KartInfo.kart = Cart;
                break;
            case 3:
                Chariot.SetActive(false);
                Wagon.SetActive(true);
                CartInt--;
                KartInfo.kart = Wagon;
                break;
            default:
                break;
        }
    }

    public void Back(){

        SceneManager.LoadScene("Menu");
        
    }

    public void Play(){
        
        SceneManager.LoadScene("Salad Circuit Cine");
        
    }

}
public static class KartInfo{

    public static GameObject helm;
    public static GameObject kart;
}