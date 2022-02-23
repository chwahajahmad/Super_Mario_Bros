using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundVolume : MonoBehaviour
{
    private GameObject BGSound;
    // Start is called before the first frame update
    void Start()
    {
        BGSound = GameObject.Find("BackgroundSoundManager");
        GetComponent<Toggle>().isOn =  BGSound.GetComponent<SoundManager>().isOn;
    }

    public void MuteBG()
    {
        BGSound.GetComponent<SoundManager>().isOn  = GetComponent<Toggle>().isOn;
    }
}
