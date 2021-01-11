using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostFXController : MonoBehaviour
{
    void Start()
    {
        PostFX();
    }

    void Update()
    {
        PostFX();
    }

    public void PostFX()
    {
        if(PlayerPrefs.GetInt("PREF_PostFX") == 1)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
