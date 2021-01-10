using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            /* Update the value received for this job */
            PlayerPrefs.SetInt("PREF_LastFunds", Stopwatch.currentValue);

            /* Calculate teh new bank balance */
            int accountValue = Stopwatch.currentValue + PlayerPrefs.GetInt("PREF_AccountValue");

            /* Update teh bank balance */
            PlayerPrefs.SetInt("PREF_AccountValue", accountValue);

            PlayerPrefs.Save();

            SceneManager.LoadSceneAsync("LevelComplete");
        }
    }
}
