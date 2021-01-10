using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text timerText;
    public Text valueText;

    public Text targetTimeText;

    public float startTime;

    public Color defaultColour;
    public Color warningColour;

    /* How much the user can get paid for the item */
    public int contractValue;
    public static int currentValue;

    /* The time the user is expected to deliver the item in.*/
    public float targetTime;

    private bool countingDown = false;


    void Start()
    {
        startTime = Time.time;
        currentValue = contractValue;

        targetTimeText.text = "TARGET: " + targetTime + "sec";

        valueText.color = defaultColour;
    }

    void Update()
    {
        /* Calculate the time elapsed */
        float t = Time.time - startTime;

        /* Punish players for going over the target time */
        if( t >= targetTime && !countingDown )
        {
            /* Remove one dollar every second */
            InvokeRepeating("DecrementValue", 0.1f, 0.01f);
            valueText.color = warningColour;
            valueText.fontSize = 20;

            /* Prevents us from constantly visitng this part of the loop */
            countingDown = true;
        }

        timerText.text = "TIMER: " + t.ToString("f3");
        valueText.text = "VALUE: M$" + currentValue;
    }

    void DecrementValue()
    {
        if( currentValue > 0 )
            currentValue -= 10;
    }
}
