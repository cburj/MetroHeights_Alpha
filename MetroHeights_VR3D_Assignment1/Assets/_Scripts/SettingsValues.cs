using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsValues : MonoBehaviour
{
    Toggle toggle;
    
    private void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();

    }
    public void RainFX()
    {
        if(toggle.isOn)
            PlayerPrefs.SetInt("PREF_RainFX", 1);
        else
            PlayerPrefs.SetInt("PREF_RainFX", 0);
        PlayerPrefs.Save();
    }

    public void PostFX()
    {
        if(toggle.isOn)
            PlayerPrefs.SetInt("PREF_PostFX", 1);
        else
            PlayerPrefs.SetInt("PREF_PostFX", 0);
        PlayerPrefs.Save();
    }
}
