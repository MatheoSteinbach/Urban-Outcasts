using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NanalinNPC : MonoBehaviour, IInteractable, IDataPersistence
{
    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera zoomCam;
    [SerializeField] CinemachineVirtualCamera fadeToBlackCam;

    [Header("Interaction Prompt")]
    [SerializeField] string prompt;

    [Header("Talksprites")]
    [SerializeField] TalkspritesNanalin talkspritesNanalin;
    [SerializeField] PlayerTalksprites talkspritesPlayer;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Positions")]
    [SerializeField] Transform positionOne;
    [SerializeField] Transform positionTwo;

    [Header("Player")]
    [SerializeField] PlayerController playerController;
    
    public string InteractionPrompt => prompt;

    public bool CanInteract => canInteract;

    private bool canInteract;

    private bool isOnNanalinDialogue = false;

    private bool isOnPositionTwo = false;
    private bool moveNanalinToPositionTwo = false;

    private void Start()
    {
        canInteract = true;
        transform.position = positionOne.transform.position;
    }

    private void Update()
    {
        if (!isOnPositionTwo && moveNanalinToPositionTwo && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            FadeCamToBlack();
            playerController.DisableMovement();
        }

        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            moveNanalinToPositionTwo = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("moveNanalinToPosition2")).value;
        }
        else if (!DialogueManager.GetInstance().dialogueIsPlaying && isOnNanalinDialogue)
        {
            talkspritesNanalin.DeactivateSelf();
            talkspritesPlayer.DeactivateSelf();
            ZoomCamTurnOff();
            playerController.EnableMovement();
            isOnNanalinDialogue = false;
        }
    }
    public bool Interact(Interactor interactor)
    {
        EnterDialogue();
        isOnNanalinDialogue = true;

        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }

        return true;
    }

    private void FadeCamToBlack()
    {
        fadeToBlackCam.m_Priority = 31;
        fadeToBlackCam.gameObject.SetActive(true);
        StartCoroutine(MoveToPositionTwo());
    }

    private void EnterDialogue()
    {
        playerController.DisableMovement();
        talkspritesNanalin.ActivateSelf();
        talkspritesPlayer.ActivateSelf();

        ZoomCamTurnOn();
    }

    IEnumerator MoveToPositionTwo()
    {
        yield return new WaitForSeconds(2.5f);
        transform.position = positionTwo.transform.position;
        fadeToBlackCam.gameObject.SetActive(false);
        isOnPositionTwo = true;
        playerController.EnableMovement();
    }

    public void SetToCanInteract()
    {
        canInteract = true;
    }
    public void SetToCanNotInteract()
    {
        canInteract = false;
    }

    public void ZoomCamTurnOn()
    {
        zoomCam.gameObject.SetActive(true);
    }
    public void ZoomCamTurnOff()
    {
        zoomCam.gameObject.SetActive(false);
    }

    public void LoadData(GameData data)
    {
        throw new System.NotImplementedException();
    }

    public void SaveData(GameData data)
    {
        throw new System.NotImplementedException();
    }
}