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

        /* DEFAULT VALUES */
        PlayerPrefs.SetFloat("PREF_MasterVolume", 1.0f);
        PlayerPrefs.SetInt("PREF_RainFX", 1);
        PlayerPrefs.SetInt("PREF_PostFX", 1);
    }

    public void RainFX()
    {
        if (toggle.isOn)
            PlayerPrefs.SetInt("PREF_RainFX", 1);
        else
            PlayerPrefs.SetInt("PREF_RainFX", 0);
        PlayerPrefs.Save();
    }

    public void PostFX()
    {
        if (toggle.isOn)
            PlayerPrefs.SetInt("PREF_PostFX", 1);
        else
            PlayerPrefs.SetInt("PREF_PostFX", 0);
        PlayerPrefs.Save();
    }

    public void VolSet(Slider volSlider)
    {
        PlayerPrefs.SetFloat("PREF_MasterVolume", volSlider.value);
    }
}
