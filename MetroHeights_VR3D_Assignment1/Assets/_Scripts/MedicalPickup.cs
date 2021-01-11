using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalPickup : MonoBehaviour
{
    public string MedicalTag;

    public GameObject player;
    private PlayerStats playerHealth;
    public GameObject toolTip;

    public AudioClip healthClip;
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider col)
    {
        /*We only pickup the item if we don't have max ammo */
        playerHealth = player.GetComponent<PlayerStats>();
        if ((col.gameObject.tag == MedicalTag) && (playerHealth.currentHealth < playerHealth.maxHealth))
        {
            toolTip.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider col)
    {
        if ((col.gameObject.tag == MedicalTag))
        {
            toolTip.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        /* Check for input and disable to tooltip */
        if (Input.GetKeyDown(KeyCode.E) && toolTip.activeSelf)
        {
            playerHealth.currentHealth = playerHealth.maxHealth;
            toolTip.SetActive(false);

            audioSource.clip = healthClip;
            audioSource.Play();
        }
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
}
