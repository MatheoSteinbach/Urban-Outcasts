using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDialogue : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera zoomCam;
    [SerializeField] CinemachineVirtualCamera blackOutCam;

    [Header("Dialogue")]
    [SerializeField] string nameTag;
    [SerializeField] TextMeshProUGUI dialogueNameText;
    [SerializeField] PlayerController playerController;
    [SerializeField] MonologueTalksprites monologueTalksprites;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [SerializeField] NanalinNPC nanalin;

    private bool isOnPlayerDialogue;
    private bool endingDialogue;
    private bool end;
    private bool playOnce;
    private void Update()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying && !end)
        {
            end = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("OutroCutscene")).value;
        }
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if(end)
            {
                SceneManager.LoadScene(6);
            }
            if (!endingDialogue && !end)
            {
                endingDialogue = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("NanalinCheckpoint2")).value;
            }
            if (endingDialogue && !playOnce)
            {
                playOnce = true;
                blackOutCam.gameObject.SetActive(true);
                nanalin.SetToCanNotInteract();
                StartCoroutine(ToEndDialogue());
            }
        }

        if (!DialogueManager.GetInstance().dialogueIsPlaying && isOnPlayerDialogue)
        {
            ZoomCamTurnOff();
            playerController.EnableMovement();
            isOnPlayerDialogue = false;
            monologueTalksprites.DeactivateSelf();
        }
    }

    public void EnterDialogue()
    {
        monologueTalksprites.ActivateSelf();
        dialogueNameText.text = nameTag;
        playerController.DisableMovement();
        ZoomCamTurnOn();
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        isOnPlayerDialogue = true;
    }

    private IEnumerator ToEndDialogue()
    {
        yield return new WaitForSeconds(2f);
        blackOutCam.gameObject.SetActive(false);

        EnterDialogue();
    }


    private void ZoomCamTurnOn()
    {
        zoomCam.gameObject.SetActive(true);
    }
    public void ZoomCamTurnOff()
    {
        zoomCam.gameObject.SetActive(false);
    }
}
