using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    /* Responsible for all the button clicks in the menus that
       do not load other scenes
    */
    public GameObject SettingsObject;
    public GameObject LevelsObject;
    public GameObject LoreObject;

    public void ShowSettings()
    {
        SettingsObject.SetActive(true);
        LevelsObject.SetActive(false);
        LoreObject.SetActive(false);
    }

    public void ShowLevels()
    {
        SettingsObject.SetActive(false);
        LevelsObject.SetActive(true);
        LoreObject.SetActive(false);
    }

    public void ShowLore()
    {
        SettingsObject.SetActive(false);
        LevelsObject.SetActive(false);
        LoreObject.SetActive(true);

    }

    public void Respawn()
    {
        string lastLevel = PlayerPrefs.GetString("PREF_CurrentLevel");
        SceneManager.LoadScene(lastLevel);
    }

    public void JumpToLevels()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
