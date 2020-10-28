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

    /* The damage each laser beam inflicts on enemies */
    public float LaserDamage = 100.0f;

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

    void ShootEnemy()
    {
        RaycastHit beam;
        if (Physics.Raycast(camera.position, camera.forward, out beam, maxDistance)
            && (beam.transform.tag == "Enemy"))
        {
            Debug.Log("Enemy Shot...");
            float enemyHP = beam.transform.GetComponent<EnemyStats>().hp - LaserDamage;

            if (enemyHP <= 0)
                Destroy(beam.transform.gameObject, 0);
            else
                beam.transform.GetComponent<EnemyStats>().hp = enemyHP;
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
}
