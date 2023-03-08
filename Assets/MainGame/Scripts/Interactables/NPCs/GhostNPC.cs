using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GhostNPC : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField] GameObject EnergyStone;

    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera zoomCam;
    [SerializeField] CinemachineVirtualCamera fadeToBlackCam;

    [Header("Interaction Prompt")]
    [SerializeField] string prompt;

    [Header("Talksprites")]
    [SerializeField] TalkspritesGhost talkspritesGhost;
    [SerializeField] PlayerTalksprites talkspritesPlayer;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Positions")]
    [SerializeField] Transform positionOne;
    [SerializeField] Transform positionTwo;

    [Header("Player")]
    [SerializeField] PlayerController playerController;

    [Header("Bracelet")]
    [SerializeField] ItemData item;

    [Header("Anims")]
    [SerializeField] Animator animator;
    
    [Header("Phone")]
    [SerializeField] PhoneUI phone;
    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    public string InteractionPrompt => prompt;

    public bool CanInteract => canInteract;

    private bool canInteract;

    private bool isOnGhostDialogue = false;

    private bool isOnPositionTwo = false;
    private bool moveGhostToPositionTwo = false;
    private bool giveNanalinsBracelet = false;
    private bool giveOnce = false;
    private bool hasQuestItemSpawned = false;

    private void Start()
    {
        giveOnce = true;
        canInteract = true;
        transform.position = positionOne.transform.position;
        animator.SetBool("houseArrow", true);
    }

    private void Update()
    {
        if (!hasQuestItemSpawned)
        {
            hasQuestItemSpawned = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("GhostCheckpoint1")).value;
            if (hasQuestItemSpawned)
            {
                EnergyStone.gameObject.SetActive(true);
            }
        }
        if (giveOnce && giveNanalinsBracelet)
        {
            Ink.Runtime.Object obj = new Ink.Runtime.BoolValue(giveNanalinsBracelet);
            DialogueManager.GetInstance().SetVariableState("hasNanalinsBracelet", obj);
            StartCoroutine(GiveNanalinArmBand());
            giveOnce = false;
        }
        
        if (!isOnPositionTwo && moveGhostToPositionTwo && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            FadeCamToBlack();
            playerController.DisableMovement();
        }

        if (DialogueManager.GetInstance().dialogueIsPlaying && isOnGhostDialogue)
        {
            giveNanalinsBracelet = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("GhostCheckpoint2")).value;
            moveGhostToPositionTwo = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("moveGhostToPosition2")).value;
        }
        else if (!DialogueManager.GetInstance().dialogueIsPlaying && isOnGhostDialogue)
        {
            talkspritesGhost.DeactivateSelf();
            talkspritesPlayer.DeactivateSelf();
            ZoomCamTurnOff();
            playerController.EnableMovement();
            isOnGhostDialogue = false;
        }
    }
    public bool Interact(Interactor interactor)
    {
        EnterDialogue();
        isOnGhostDialogue = true;

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
        talkspritesGhost.ActivateSelf();
        talkspritesPlayer.ActivateSelf();

        ZoomCamTurnOn();
    }
    IEnumerator GiveNanalinArmBand()
    {
        yield return new WaitForSeconds(1);
        
        InventoryManager.Instance.AddItem(item);
        audioSource.Play();
        phone.OpenPhoneOnInventory();
    }
    IEnumerator MoveToPositionTwo()
    {
        yield return new WaitForSeconds(4); 
        animator.SetBool("houseArrow", false);
        transform.position = positionTwo.transform.position;
        fadeToBlackCam.gameObject.SetActive(false);
        isOnPositionTwo = true;
        playerController.EnableMovement();
        phone.OpenPhoneOnInventory();
    }

    public void ZoomCamTurnOn()
    {
        zoomCam.gameObject.SetActive(true);
    }
    public void ZoomCamTurnOff()
    {
        zoomCam.gameObject.SetActive(false);
    }
    public void SetToCanInteract()
    {
        canInteract = true;
    }
    public void SetToCanNotInteract()
    {
        canInteract = false;
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