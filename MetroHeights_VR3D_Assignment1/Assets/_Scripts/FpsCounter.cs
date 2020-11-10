using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    public Text fpsText;
    public int avgFrameRate;

    void Update()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        fpsText.text = avgFrameRate.ToString() + " FPS";
    }
}