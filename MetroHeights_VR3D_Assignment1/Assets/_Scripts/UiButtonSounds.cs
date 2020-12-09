using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/* https://gamedev.stackexchange.com/questions/116801/how-can-i-detect-that-the-mouse-is-over-a-button-so-that-i-can-display-some-ui-t*/

public class UiButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip hoverSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData pointer)
    {
        audioSource.clip = hoverSound;
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData pointer)
    {
    }
}
