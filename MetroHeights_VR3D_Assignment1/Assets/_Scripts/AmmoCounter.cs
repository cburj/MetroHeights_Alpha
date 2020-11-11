using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public GameObject blaster;
    private float magazineSize;
    private float ammoCount;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        magazineSize = blaster.transform.GetComponent<GrapplingGun>().magazineSize;
        ammoCount = blaster.transform.GetComponent<GrapplingGun>().getAmmoCount();

        text.text = ammoCount + "/" + magazineSize;
    }
}
