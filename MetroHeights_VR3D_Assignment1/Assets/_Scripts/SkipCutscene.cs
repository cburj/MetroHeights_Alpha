using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    /*This script is designed to allow the user to press a specific
      key to skip the current scene/cutscene
    */

    public Text prompt;

    public string NextScene;

    void Start()
    {
        if (prompt == null)
        {
            prompt = gameObject.GetComponent<Text>();
        }
        prompt.enabled = false;
    }

    void Update()
    {
        if( Input.anyKey )
        {
            prompt.enabled = true;
            StartCoroutine("delay");
        }

        if( prompt.enabled && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(NextScene);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);

        prompt.enabled = false;
    }
}
