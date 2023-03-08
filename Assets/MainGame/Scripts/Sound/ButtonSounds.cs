using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hoverSound;
    [SerializeField] AudioClip clickSound;

    public void HoverSound()
    {
        audioSource.PlayOneShot(hoverSound);
    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
