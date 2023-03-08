using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    void Start() { videoPlayer.loopPointReached += CheckOver; }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(4);
        }
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(4);
    }
}
