using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level1ToLevel2 : MonoBehaviour
{
    [Header("Phone")]
    [SerializeField] PhoneUI phone;

    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera level2Cam;
    [SerializeField] CinemachineVirtualCamera fadeToBlackCam;

    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] PlayerController playerController;

    [SerializeField] Transform teleportPoint;
    private bool playOnce = true;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(playOnce)
            {
                phone.ClosePhone();
                playerController.DisableMovement();
                fadeToBlackCam.m_Priority = 14;
                fadeToBlackCam.gameObject.SetActive(true);
                StartCoroutine(ChangeCameras());
                playOnce = false;

            }
        }
    }
  
    IEnumerator ChangeCameras()
    {
        yield return new WaitForSeconds(2);
        player.transform.position = teleportPoint.position;
        playerController.EnableMovement();
        level2Cam.gameObject.SetActive(true);
        fadeToBlackCam.transform.position = level2Cam.transform.position;
        fadeToBlackCam.gameObject.SetActive(false);
        playOnce = true;
    }
}
