using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdeSettings : MonoBehaviour
{
    public GameObject settingsPanelUI;

    public void hide()
    {
        Time.timeScale = 1;
        settingsPanelUI.SetActive(false);
    }
}
