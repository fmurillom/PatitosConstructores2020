using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
   public void SetVolume(float volume){

       audioMixer.SetFloat("FXLevel", volume);

   }

   public void SetMusic(float volume){

       audioMixer.SetFloat("MusicLevel", volume);
       
   }
}
