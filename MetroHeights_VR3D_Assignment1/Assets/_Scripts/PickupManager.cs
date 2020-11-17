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
        /*We only pickup the item if we don't have max ammo */
        grapple = blaster.GetComponent<GrapplingGun>();
        if( ( col.gameObject.tag == AmmoTag ) && ( grapple.getAmmoCount() < grapple.magazineSize ) )
        {
            grapple.resetAmmoCount(grapple.magazineSize);
            Destroy(col.gameObject);
        }
    }
}
