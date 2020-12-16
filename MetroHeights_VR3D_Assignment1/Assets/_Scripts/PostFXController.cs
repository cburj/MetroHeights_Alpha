using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostFXController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PostFX();
    }

    // Update is called once per frame
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
