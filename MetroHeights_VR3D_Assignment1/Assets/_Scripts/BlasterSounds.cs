using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SOURCES:
//http://answers.unity.com/answers/1162005/view.html

public class BlasterSounds : MonoBehaviour
{
    //Array for blaster sounds
    public AudioClip[] blasterSounds;
    private AudioClip blasterClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("SHOOT");
            int index = Random.Range(0, blasterSounds.Length);
            blasterClip = blasterSounds[index];
            audioSource.clip = blasterClip;
            audioSource.Play();
        }
    }
}
