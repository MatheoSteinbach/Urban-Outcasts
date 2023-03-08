using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class OutroCutscene : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    void Start() { videoPlayer.loopPointReached += CheckOver; }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            videoPlayer.Stop();
            StartCoroutine(ChangeToMainMenu()); 
        }
    }
    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        StartCoroutine(ChangeToMainMenu());
    }
    IEnumerator ChangeToMainMenu()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);
    }
}
