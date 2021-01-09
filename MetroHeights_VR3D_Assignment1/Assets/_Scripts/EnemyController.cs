using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* SOURCES: */
/* http://answers.unity.com/answers/260874/view.html*/
/* https://docs.unity3d.com/ScriptReference/ParticleSystem.MainModule-loop.html*/

public class EnemyController : MonoBehaviour
{
    public float maxHP = 100.0f;
    public float hp;

    /*The time between each shot the enemy makes*/
    public float shotDelta = 1.0f;

    public GameObject explosion;
    public GameObject muzzleFlash;
    public GameObject barrelPos;

    public Transform playerTarget; /*The player to look at*/

    public int maxAmmo = 4;

    private int ammoRemaining;

    public int damage = 25;     /*Amount of damage each bullet does*/
    public int range = 10;      /* The minimum distance between the player and enemy before we shoot at them*/

    public int droneValue; /* The reward the user receives for killing this drone */

    private bool isShooting = false;

    /*AUDIO*/
    public AudioClip[] blasterSounds;
    private AudioClip blasterClip;
    private AudioSource audioSource;

    /*HEALTH BAR*/
    public Slider slider;

    [SerializeField]
    private float lerpSpeed = 2;

    private void Start()
    {
        ammoRemaining = maxAmmo;
        audioSource = gameObject.GetComponent<AudioSource>();

        /*Health Bar*/
        hp = maxHP;
        slider.value = CalcHealth();

        /* Get the drone range multiplier*/
        float modifier = PlayerPrefs.GetFloat("PREF_DroneRange");
        if( modifier >= 1 || modifier <= 2)
            range = (int)(range * modifier);
    }

    /* Returns the enemy health as a normalised float */
    public float CalcHealth()
    {
        return (hp/(maxHP));
    }

    public void RecieveDamage(float damage)
    {
        float currentHP = CalcHealth();
        if( hp - damage <= 0 )
        {
            Kill();
        }
        else
        {
            hp -= damage;
            slider.value = Mathf.MoveTowards( currentHP, CalcHealth(), (Time.deltaTime * lerpSpeed ) );
        }
    }

    public void Kill()
    {
        /* Reward the player for killing the drone */
        Stopwatch.currentValue += droneValue;

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

    public void shootAnimation()
    {
        GameObject shootEffect = Instantiate(muzzleFlash) as GameObject;

        //Set its position to the position of the enemy.
        shootEffect.transform.position = barrelPos.transform.position;

        //Create a new reference to the particle system on the game object.
        ParticleSystem particles = shootEffect.GetComponent<ParticleSystem>();

        //Make a new reference/variable that points to the "main" variable of the PS.
        var main = particles.main;

        //Prevent looping
        main.loop = false;
        //Play the PS
        particles.Play();

        //Destroy the PS once its finished
        Destroy(shootEffect.gameObject, main.duration);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shotDelta);

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

            shootAnimation();

            float playerHP = beam.transform.GetComponent<PlayerStats>().currentHealth - damage;
            
            beam.transform.GetComponent<PlayerStats>().currentHealth = playerHP;
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