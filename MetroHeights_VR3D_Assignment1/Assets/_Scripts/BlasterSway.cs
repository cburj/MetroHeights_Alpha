using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterSway : MonoBehaviour
{

    /* SOURCES: */
    /* https://www.youtube.com/watch?v=hifCUD3dATs */

    public float amount;
    public float smoothAmount;
    public float maxAmount;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        //If the mouse is moving left, then the gun moves right and vice versa...
        float movementX = - Input.GetAxis("Mouse X") * amount;
        float movementY = - Input.GetAxis("Mouse Y") * amount;

        /* Prevent the movement from exceeding a specified distance */
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

        /*Create the new final position */
        Vector3 finalPosition = new Vector3(movementX, movementY, 0);

        /*Move it to that position */
        transform.localPosition = Vector3.Lerp(transform.localPosition, ( finalPosition + initialPosition ), ( smoothAmount * Time.deltaTime ) );
    }
}
