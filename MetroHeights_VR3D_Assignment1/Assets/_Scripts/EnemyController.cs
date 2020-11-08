﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* SOURCES: */
/* http://answers.unity.com/answers/260874/view.html*/
/* https://docs.unity3d.com/ScriptReference/ParticleSystem.MainModule-loop.html*/

public class EnemyController : MonoBehaviour
{
    public float hp = 100.0f;

    /*The time between each shot the enemy makes*/
    public float shotDelta = 1.0f;

    public GameObject explosion;

    public Transform playerTarget; /*The player to look at*/

    public int maxAmmo = 4;

    private int ammoRemaining;

    public int damage = 25;     /*Amount of damage each bullet does*/
    public int range = 10;      /* The minimum distance between the player and enemy before we shoot at them*/

    private bool isShooting = false;

    /*AUDIO*/
    public AudioClip[] blasterSounds;
    private AudioClip blasterClip;
    private AudioSource audioSource;

    private void Start()
    {
        ammoRemaining = maxAmmo;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Kill()
    {
        //Pass in the particle system prefab as a game object.
        GameObject explosionEffect = Instantiate(explosion) as GameObject;

        //Set its position to the position of the enemy.
        explosionEffect.transform.position = transform.position;

        //Create a new reference to the particle system on the game object.
        ParticleSystem expParticles = explosionEffect.GetComponent<ParticleSystem>();

        //Make a new reference/variable that points to the "main" variable of the PS.
        var main = expParticles.main;

        //Prevent looping
        main.loop = false;
        //Play the PS
        expParticles.Play();

        //Destroy the PS once its finished
        Destroy(explosionEffect.gameObject, main.duration);

        //Destroy the enemy
        Destroy(gameObject);
    }

    private void Update()
    {
        /* Follow the players position */
        transform.LookAt(playerTarget);
        GetPlayerProximity();
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2);

        //Cast the ray and shoot if we can collide.
        RaycastHit beam;
        if (Physics.Raycast(transform.position, transform.forward, out beam, range)
            && (beam.transform.tag == "Player"))
        {
            /*Play a random Gun Shot Sound*/
            int index = Random.Range(0, blasterSounds.Length);
            blasterClip = blasterSounds[index];
            audioSource.clip = blasterClip;
            audioSource.Play();

            float playerHP = beam.transform.GetComponent<PlayerStats>().currentHealth - damage;

            if (playerHP <= 0)
            {
                /*Debug.Log("You are DEAD!");*/
            }
            else
            {
                beam.transform.GetComponent<PlayerStats>().currentHealth = playerHP;
            }
        }
        /*We are no longer shooting*/
        isShooting = false;
    }

    public void GetPlayerProximity()
    {
        /* Get the distance between the Enemy and Player */
        float distance = Vector3.Distance(playerTarget.position, transform.position);

        /* If the Player is within the enemy's range...*/
        if (distance <= range && isShooting == false)
        {
            isShooting = true;
            StartCoroutine("Shoot");
        }
    }
}