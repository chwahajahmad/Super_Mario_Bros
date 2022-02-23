using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeChange : MonoBehaviour
{
    private GameObject BGSound;
    private GameObject VFXSound;
    // Start is called before the first frame update
    void Start()
    {
        BGSound = GameObject.Find("BackgroundSoundManager");
        VFXSound =  GameObject.Find("VFXSoundManager");
        GetComponent<Slider>().value =  BGSound.GetComponent<SoundManager>().vol;
    }

    public void SetVolume()
    {
        BGSound.GetComponent<SoundManager>().vol = GetComponent<Slider>().value;
        VFXSound.GetComponent<VFXSOUNDMANAGER>().vol = GetComponent<Slider>().value;
    }
}
