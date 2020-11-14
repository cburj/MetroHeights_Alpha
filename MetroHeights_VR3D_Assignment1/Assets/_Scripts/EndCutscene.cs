using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EndCutscene : MonoBehaviour
{
    public VideoPlayer video;

    void Start()
    {
        StartCoroutine("checkCutscene");
    }

    IEnumerator checkCutscene()
    {
        while(( video.frame) <= 0 || (video.isPlaying == true))
        {
            yield return null;
        }

        SceneManager.LoadScene("Level01");
    }
}
