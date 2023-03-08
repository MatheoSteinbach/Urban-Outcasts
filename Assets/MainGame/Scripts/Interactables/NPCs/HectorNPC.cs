using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HectorNPC : MonoBehaviour, IInteractable, IDataPersistence
{
    [Header("Item")]
    [SerializeField] GameObject AncientCore;

    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera zoomCam;
    [SerializeField] CinemachineVirtualCamera fadeToBlackCam;

    [Header("Talksprites")]
    [SerializeField] TalkspritesHector talkspritesHector;
    [SerializeField] PlayerTalksprites talkspritesPlayer;

    [Header("Interaction Prompt")]
    [SerializeField] string prompt;

    [Header("Ink JSON")]
    [SerializeField] TextAsset inkJSON;

    [Header("Positions")]
    [SerializeField] Transform positionOne;
    [SerializeField] Transform positionTwo;

    [Header("Player")]
    [SerializeField] PlayerController playerController;

    [Header("Phone")]
    [SerializeField] PhoneUI phone;
    public string InteractionPrompt => prompt;

    public bool CanInteract => canInteract;

    private bool canInteract;

    private bool isOnHectorDialogue = false;

    private bool isOnPositionTwo = false;
    private bool moveHectorToPositionTwo = false;
    private bool hasQuestItemSpawned = false;

    private void Start()
    {
        transform.position = positionOne.transform.position;
        canInteract = true;
    }
    private void Update()
    {
        if(!hasQuestItemSpawned)
        {
            hasQuestItemSpawned = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("HectorCheckpoint1")).value;
            if(hasQuestItemSpawned)
            {
                AncientCore.gameObject.SetActive(true);
            }
        }
        if(!isOnPositionTwo && moveHectorToPositionTwo && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            FadeCamToBlack();
            playerController.DisableMovement();
        }

        if (DialogueManager.GetInstance().dialogueIsPlaying && isOnHectorDialogue)
        {
            moveHectorToPositionTwo = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("moveHectorToPosition2")).value;
        }
        else if (!DialogueManager.GetInstance().dialogueIsPlaying && isOnHectorDialogue)
        {
            talkspritesHector.DeactivateSelf();
            talkspritesPlayer.DeactivateSelf();
            ZoomCamTurnOff();
            playerController.EnableMovement();

            phone.OpenPhoneOnInventory();
            isOnHectorDialogue = false;
        }
    }
    public bool Interact(Interactor interactor)
    {
        EnterDialogue();
        isOnHectorDialogue = true;

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
        talkspritesHector.ActivateSelf();
        talkspritesPlayer.ActivateSelf();

        ZoomCamTurnOn();
    }

    IEnumerator MoveToPositionTwo()
    {
        yield return new WaitForSeconds(4);
        transform.position = positionTwo.transform.position;
        fadeToBlackCam.gameObject.SetActive(false);
        isOnPositionTwo = true;
        
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