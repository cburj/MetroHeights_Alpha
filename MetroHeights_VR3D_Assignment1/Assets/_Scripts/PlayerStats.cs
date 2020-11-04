using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100.0f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
}
