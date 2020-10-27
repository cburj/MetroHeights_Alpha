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

    /*Crosshair Stuff*/
    /*public RawImage Crosshair;
    public Texture GreenCrosshair;
    public Texture RedCrosshair;*/

    /*Spring Settings*/
    public float springForce = 250f;
    public float springDamper = 5f;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
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

        /*Check if we can make the grapple*/
        /*CrosshairColor();*/
    }

    void StartGrapple()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance))
        {
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
    }

    /*Casts rays so that we can visually confirm if a 
       a grapple is possible at the current distance.
       */
    /*void CrosshairColor()
    {
        RaycastHit beam;
        if (Physics.Raycast(camera.position, camera.forward, out beam, maxDistance))
        {
            Crosshair.texture = GreenCrosshair;
        }
        else
        {
            Crosshair.texture = RedCrosshair;
        }
    }*/

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
}
