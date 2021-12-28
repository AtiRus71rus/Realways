using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Audio;

public class AudioController : MonoBehaviour {

    public AudioMixer audioMixer;

    string nameMusic = "MusicValue";
    string nameSound= "SoundValue";

    public GameObject imageSoundOFF;
    public GameObject imageSoundON;

    public GameObject imageMusicOFF;
    public GameObject imageMusicON;

    public void Start()
    {
        if (imageMusicOFF != null)
        {
            float a = 0;
            Debug.Log(a);
            audioMixer.GetFloat(nameSound, out a);
            imageSoundOFF.SetActive( a!= 0);
            imageSoundON.SetActive(a == 0);

            audioMixer.GetFloat(nameMusic, out a);
            imageMusicOFF.SetActive(a != 0);
            imageMusicON.SetActive(a == 0);
        }
    }

    public void MuteMusic()
    {
        audioMixer.SetFloat(nameMusic, -80);
    }

    public void OnMuteMusic()
    {
        audioMixer.SetFloat(nameMusic, 0);
    }

    public void MuteSound()
    {
        audioMixer.SetFloat(nameSound, -80);
    }

    public void OnMuteSound()
    {
        audioMixer.SetFloat(nameSound, 0);
    }
}
