using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource[] audioSources;
    public Slider slider;


    public void SetVolume()
    {
       
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = slider.value;
        }
    }
}
