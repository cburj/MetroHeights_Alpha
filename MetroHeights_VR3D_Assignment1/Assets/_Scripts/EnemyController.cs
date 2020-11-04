using System.Collections;
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

    private void Start()
    {
        ammoRemaining = maxAmmo;
        StartCoroutine("Shoot");
    }

    public void Kill()
    {
        //Pass in the particle system prefab as a game object.
        GameObject explosionEffect = Instantiate(explosion)
                                         as GameObject;

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
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            Debug.Log(">>> ENEMY SHOOTING");
            yield return new WaitForSeconds(shotDelta);
        }
    }
}
