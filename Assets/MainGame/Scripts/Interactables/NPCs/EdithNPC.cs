using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class EdithNPC : MonoBehaviour, IInteractable, IDataPersistence
{
    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera zoomCam;
    [SerializeField] CinemachineVirtualCamera fadeToBlackCam;
    [SerializeField] float timeForFade;

    [Header("Interaction Prompt")]
    [SerializeField] string prompt;

    [Header("Talksprites")]
    [SerializeField] TalkspritesEdith talkspritesEdith;
    [SerializeField] PlayerTalksprites talkspritesPlayer;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Positions")]
    [SerializeField] Transform positionOne;
    [SerializeField] Transform positionTwo;

    [Header("Player")]
    [SerializeField] PlayerController playerController;
    [Header("GoldBag")]
    [SerializeField] GameObject goldbag;

    public string InteractionPrompt => prompt;
    public bool CanInteract => canInteract;

    private bool canInteract;

    private bool isOnEdithDialogue = false;

    private bool isOnPositionTwo = false;
    private bool moveEdithToPositionTwo = false;

    private void Start()
    {
        canInteract = true;
        transform.position = positionOne.transform.position;
    }

    private void Update()
    {
        if (!isOnPositionTwo && moveEdithToPositionTwo && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            FadeCamToBlack();
            goldbag.SetActive(false);
            playerController.DisableMovement();
        }

        if (DialogueManager.GetInstance().dialogueIsPlaying && isOnEdithDialogue)
        {
            moveEdithToPositionTwo = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("moveEdithToPosition2")).value;
        }
        else if (!DialogueManager.GetInstance().dialogueIsPlaying && isOnEdithDialogue)
        {
            talkspritesEdith.DeactivateSelf();
            talkspritesPlayer.DeactivateSelf();
            ZoomCamTurnOff();
            playerController.EnableMovement();
            isOnEdithDialogue = false;
        }
    }
    public bool Interact(Interactor interactor)
    {
        EnterDialogue();
        isOnEdithDialogue = true;

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
        talkspritesEdith.ActivateSelf();
        talkspritesPlayer.ActivateSelf();

        ZoomCamTurnOn();
    }

    IEnumerator MoveToPositionTwo()
    {
        yield return new WaitForSeconds(timeForFade);
        goldbag.SetActive(true);
        transform.position = positionTwo.transform.position;
        fadeToBlackCam.gameObject.SetActive(false);
        isOnPositionTwo = true;
        playerController.EnableMovement();
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