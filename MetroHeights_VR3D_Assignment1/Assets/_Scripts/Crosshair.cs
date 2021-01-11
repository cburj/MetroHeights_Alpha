using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    /* Script used to visually represent whether the user's
       grappling gun will actually fire if they left click
    */

    public Text crosshair;

    /* Colours for the crosshair */
    public Color falseCol;
    public Color trueCol;

    public Transform camera;

    public GrapplingGun blaster;

    // Start is called before the first frame update
    void Start()
    {
        crosshair.color = falseCol;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit beam;
        if (Physics.Raycast(camera.position, camera.forward, out beam, blaster.maxDistance))
        {
            crosshair.color = trueCol;
        }
        else
        {
            crosshair.color = falseCol;
        }
    }
}
