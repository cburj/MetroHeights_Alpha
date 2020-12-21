using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100.0f;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void LateUpdate()
    {
        if( currentHealth <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
