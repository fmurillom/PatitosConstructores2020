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

    //3D
    public GameObject BlueHelm3D;
    public GameObject GreenHelm3D;
    public GameObject RedHelm3D;
    public GameObject Cart3D;
    public GameObject Wagon3D;
    public GameObject Chariot3D;
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
                KartInfo.helm = GreenHelm3D;
                break;
            case 2:
                GreenHelm.SetActive(false);
                RedHelm.SetActive(true);
                HelmInt++;
                KartInfo.helm = RedHelm3D;
                break;
            case 3:
                RedHelm.SetActive(false);
                BlueHelm.SetActive(true);
                HelmInt = 1;
                KartInfo.helm = BlueHelm3D;
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
                KartInfo.helm = RedHelm3D;
                break;
            case 2:
                GreenHelm.SetActive(false);
                BlueHelm.SetActive(true);
                HelmInt--;
                KartInfo.helm = BlueHelm3D;
                break;
            case 3:
                RedHelm.SetActive(false);
                GreenHelm.SetActive(true);
                HelmInt--;
                KartInfo.helm = GreenHelm3D;
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
                KartInfo.kart = Wagon3D;
                break;
            case 2:
                Wagon.SetActive(false);
                Chariot.SetActive(true);
                CartInt++;
                KartInfo.kart = Chariot3D;
                break;
            case 3:
                Chariot.SetActive(false);
                Cart.SetActive(true);
                CartInt = 1;
                KartInfo.kart = Cart3D;
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
                KartInfo.kart = Chariot3D;
                break;
            case 2:
                Wagon.SetActive(false);
                Cart.SetActive(true);
                CartInt--;
                KartInfo.kart = Cart3D;
                break;
            case 3:
                Chariot.SetActive(false);
                Wagon.SetActive(true);
                CartInt--;
                KartInfo.kart = Wagon3D;
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