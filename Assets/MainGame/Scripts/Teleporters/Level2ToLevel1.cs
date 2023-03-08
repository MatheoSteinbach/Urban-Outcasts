using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level2ToLevel1 : MonoBehaviour
{
    [Header("Phone")]
    [SerializeField] PhoneUI phone;

    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera level2Cam;
    [SerializeField] CinemachineVirtualCamera fadeToBlackCam;
    [SerializeField] CinemachineVirtualCamera level1Cam;

    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;

    [SerializeField] Transform teleportPoint;
    private bool playOnce = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playOnce)
            {
                phone.ClosePhone();
                playerController.DisableMovement();
                fadeToBlackCam.m_Priority = 20;
                fadeToBlackCam.gameObject.SetActive(true);
                StartCoroutine(ChangeCameras());
                playOnce = false;

            }
        }
    }

    IEnumerator ChangeCameras()
    {
        yield return new WaitForSeconds(2);
        playerController.EnableMovement();
        player.transform.position = teleportPoint.position;
        level2Cam.gameObject.SetActive(false);
        fadeToBlackCam.transform.position = level1Cam.transform.position;
        fadeToBlackCam.gameObject.SetActive(false);
        playOnce = true;
        //StopCoroutine(ChangeCameras());
    }
}