using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    private void Start()
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
