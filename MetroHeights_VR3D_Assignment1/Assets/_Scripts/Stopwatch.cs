using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public Text timerText;
    public Text valueText;
    public float startTime;

    public Color defaultColour;
    public Color warningColour;

    /* How much the user can get paid for the item */
    public int contractValue;
    public static int currentValue;

    /* The time the user is expected to deliver the item in.*/
    public float targetTime;


    void Start()
    {
        startTime = Time.time;
        currentValue = contractValue;

        valueText.color = defaultColour;
    }

    void Update()
    {
        float t = Time.time - startTime;

        if( t >= targetTime )
        {
            InvokeRepeating("DecrementValue", 1.0f, 1.0f);
            valueText.color = warningColour;
        }

        timerText.text = "TIMER: " + t.ToString("f3");
        valueText.text = "VALUE: M$" + currentValue;
    }

    void DecrementValue()
    {
        currentValue -= 1;
    }
}
