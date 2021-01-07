using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryNode : MonoBehaviour
{
    public GameObject prompt;
    public string DeliveryNodeTag;

    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == DeliveryNodeTag) )
        {
            prompt.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider col)
    {
        if ((col.gameObject.tag == DeliveryNodeTag))
        {
            prompt.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && prompt.activeSelf)
        {
            Debug.Log("YOU HAVE DELIVERED AN ITEM");
        }
    }
}
