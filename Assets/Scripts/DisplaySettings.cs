using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySettings : MonoBehaviour
{
    public GameObject settingsPanelUI;

    public void display()
    {
        Time.timeScale = 0;
        settingsPanelUI.SetActive(true);
    }
}
