using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterFlex : MonoBehaviour
{
    Animator gunAnimator;
    void Start()
    {
        gunAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Play the gun spin animation
            gunAnimator.SetTrigger("Flex");
        }
    }
}
