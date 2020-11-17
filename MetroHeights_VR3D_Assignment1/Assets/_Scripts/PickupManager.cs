using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public string AmmoTag;
    public GameObject blaster;

    private GrapplingGun grapple;

    private void OnTriggerEnter(Collider col)
    {
        if( col.gameObject.tag == AmmoTag )
        {
            grapple = blaster.GetComponent<GrapplingGun>();
            grapple.resetAmmoCount(grapple.magazineSize);
            Destroy(col.gameObject);
        }
    }
}
