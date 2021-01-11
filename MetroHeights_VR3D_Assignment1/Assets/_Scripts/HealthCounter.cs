using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public GameObject player;
    private float healthSize;
    private float health;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSize = player.transform.GetComponent<PlayerStats>().maxHealth;
        health = player.transform.GetComponent<PlayerStats>().currentHealth;

        text.text = health + "/" + healthSize +"HP";
    }
}
