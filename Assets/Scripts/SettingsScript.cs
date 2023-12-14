using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    //0-->Low, 1-->Medium, 2-->High
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
