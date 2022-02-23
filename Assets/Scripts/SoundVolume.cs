using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundVolume : MonoBehaviour
{
  private GameObject VFXSound;
    // Start is called before the first frame update
    void Start()
    {
        VFXSound =  GameObject.Find("VFXSoundManager");
        GetComponent<Toggle>().isOn =  VFXSound.GetComponent<VFXSOUNDMANAGER>().isOn;
    }

    public void BGMUTE()
    {
        VFXSound.GetComponent<VFXSOUNDMANAGER>().isOn = GetComponent<Toggle>().isOn;
    }
}
