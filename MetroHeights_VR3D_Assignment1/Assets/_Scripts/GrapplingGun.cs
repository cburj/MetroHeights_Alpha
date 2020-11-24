using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    public float maxDistance = 100.0f;
    private SpringJoint joint;
    /*Spring Settings*/
    public float springForce = 250f;
    public float springDamper = 5f;

    /*Blaster ParticleFX*/
    public GameObject blasterFX;
    public Transform barrelPos;

    /* The damage each laser beam inflicts on enemies */
    public float LaserDamage = 100.0f;

    /*Reference to the ammo slider/indicator */
    public GameObject slider;

    /*Seconds between each grapple shot */
    public float shotInterval = 0.5f;
    public int magazineSize = 10;
    private int ammoCount = 0;
    private bool canShoot = true;
    public GameObject indicator;

    /*AUDIO*/
    public AudioClip[] blasterSounds;
    private AudioClip blasterClip;
    private AudioSource audioSource;

    public AudioClip reloadSound;
    public AudioClip dryFireSound;

    Animator gunAnimator;

    void Start()
    {
        gunAnimator = GetComponent<Animator>();
        ammoCount = magazineSize;

        audioSource = gameObject.GetComponent<AudioSource>();

        slider.SetActive(false);
    }

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
            ShootEnemy();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        /*We only want to draw the rope after everything else
        has been updated - otherwise we get a stuttery rope */
        DrawRope();
    }

    public int getAmmoCount()
    {
        return ammoCount;
    }

    void ShootFX()
    {
        GameObject explosionEffect = Instantiate(blasterFX) as GameObject;

        //Set its position to the position of the enemy.
        explosionEffect.transform.position = barrelPos.transform.position;

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
    }


    void StartGrapple()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance)
            && canShoot == true
            && ammoCount > 0)
        {
            //We can play the animation now...
            gunAnimator.SetTrigger("Shoot");

            /*Play a random blaster sound from the array */
            int index = Random.Range(0, blasterSounds.Length);
            blasterClip = blasterSounds[index];
            audioSource.clip = blasterClip;
            audioSource.Play();

            ammoCount--;

            if (ammoCount <= 0)
            {
                /*Show the slider indicator */
                slider.SetActive(true);
            }

            /* We let the controller know we are shooting*/
            /* This prevents the player from shooting too fast */
            canShoot = false;
            StartCoroutine("Shoot");

            //Play the particle fx
            ShootFX();

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            /* The distance the grapple will try to keep from grapple point.*/
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = springForce;
            joint.damper = springDamper;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
        /* They have no ammo left at this point*/
        if (ammoCount <= 0)
        {
            /* Play the Dry-Fire Sound */
            blasterClip = dryFireSound;
            audioSource.clip = blasterClip;
            audioSource.Play();
        }
    }

    void ShootEnemy()
    {
        RaycastHit beam;
        if (Physics.Raycast(camera.position, camera.forward, out beam, maxDistance)
            && (beam.transform.tag == "Enemy")
            && ammoCount > 0)
        {
            float enemyHP = beam.transform.GetComponent<EnemyController>().hp - LaserDamage;

            beam.transform.GetComponent<EnemyController>().RecieveDamage(LaserDamage);
        }
    }

    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    void DrawRope()
    {
        /*if the joint doesn't exist, don't draw the rope!*/
        if (!joint)
            return;

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    IEnumerator Shoot()
    {
        //indicator.SetActive(false);
        yield return new WaitForSeconds(shotInterval);
        /*We are no longer shooting*/
        canShoot = true;
        //indicator.SetActive(true);
    }

    public void resetAmmoCount(int count)
    {
        ammoCount = count;
        gunAnimator.SetTrigger("Reload");

        /* Play the Reload Sound */
        blasterClip = reloadSound;
        audioSource.clip = blasterClip;
        audioSource.Play();

        /*Hide the slider indicator */
        slider.SetActive(false);
    }
}
