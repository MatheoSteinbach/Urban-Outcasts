using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UIPromptAnchor : MonoBehaviour
{
    [SerializeField] RectTransform UIprompt;
    [SerializeField] CinemachineVirtualCamera fadeToBlackCam;

    private bool isOnFadeToBlackCam;

    private void Start()
    {
        isOnFadeToBlackCam = false;
    }
    private void Update()
    {
        UIprompt.anchoredPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (fadeToBlackCam.gameObject.activeSelf)
        {
            UIprompt.gameObject.SetActive(false);
            isOnFadeToBlackCam = true;
        }
        else if(!fadeToBlackCam.gameObject.activeSelf && isOnFadeToBlackCam)
        {
            UIprompt.gameObject.SetActive(true);
            isOnFadeToBlackCam = false;
        }
    }
}
