using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolume : MonoBehaviour
{
    void Update()
    {
        /*If no pref has been set, set it to 1 */
        if(!PlayerPrefs.HasKey("PREF_MasterVolume"))
        {
            AudioListener.volume = 1.0f;
            PlayerPrefs.SetFloat("PREF_MasterVolume", 1.0f);
        }
        else
            AudioListener.volume = PlayerPrefs.GetFloat("PREF_MasterVolume");
    }
}
