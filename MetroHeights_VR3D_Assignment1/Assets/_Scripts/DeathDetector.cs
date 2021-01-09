using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathDetector : MonoBehaviour
{

    public string DeathBox;

    private void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == DeathBox))
        {
            SceneManager.LoadSceneAsync("GameOver");
        }
    }
}
