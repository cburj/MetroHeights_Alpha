using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [Tooltip("Name of the scene the button should load.")]
    public string sceneName;

    public void ChangeScene()
    {
        PlayerPrefs.SetString("PREF_CurrentLevel", sceneName);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneName);
    }
}
