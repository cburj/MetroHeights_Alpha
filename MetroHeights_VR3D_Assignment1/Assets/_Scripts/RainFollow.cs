﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Used to allow the rain to follow the position of the player*/
/* This means we can just render a 10x10x10 volume of particles,*/
/* rather than a global-sized volume of rain */
public class RainFollow : MonoBehaviour
{
    public Transform Player;
    public AudioSource rainSounds;

    void LateUpdate()
    {
        float RainY = transform.position.y;
        float PlayerX = Player.transform.position.x;
        float PlayerZ = Player.transform.position.z;
        float PlayerY = Player.transform.position.y;

        transform.position = new Vector3(PlayerX, RainY, PlayerZ);

        /* Enable/Disable Rain Effects*/
        RainFX();
    }

    private void Start()
    {
        rainSounds = gameObject.GetComponent<AudioSource>();

        /* Enable/Disable Rain Effects*/
        RainFX();
    }

    public void RainFX()
    {
        if(PlayerPrefs.GetInt("PREF_RainFX") == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            rainSounds.Stop();
        }
    }
}

