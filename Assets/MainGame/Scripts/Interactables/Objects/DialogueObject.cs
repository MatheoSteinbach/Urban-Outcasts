using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueObject : MonoBehaviour, IInteractable
{
    [Header("Cameras")]
    [SerializeField] CinemachineVirtualCamera zoomCam;

    [Header("Interaction Prompt")]
    [SerializeField] string prompt;

    [SerializeField] string nameTag;
    [SerializeField] TextMeshProUGUI dialogueNameText;
    [SerializeField] PlayerController playerController;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [Header("Animations")]
    [SerializeField] Animator arrowAnimator;

    public string InteractionPrompt => prompt;

    public bool CanInteract => canInteract;

    private bool canInteract;

    private bool isOnDialogue;
    private void Start()
    {
        isOnDialogue = false;
        canInteract = true;
    }

    private void Update()
    {
        if(canInteract)
        {
            arrowAnimator.gameObject.SetActive(true);
        }
        else
        {
            arrowAnimator.gameObject.SetActive(false);
        }
        if(!DialogueManager.GetInstance().dialogueIsPlaying && isOnDialogue)
        {
            ZoomCamTurnOff();
            playerController.EnableMovement();
            isOnDialogue = false;
        }
    }
    public bool Interact(Interactor interactor)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying && canInteract)
        {
            dialogueNameText.text = nameTag;
            playerController.DisableMovement();
            ZoomCamTurnOn();
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            canInteract = false;
            isOnDialogue = true;
        }

        return true;
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

}
