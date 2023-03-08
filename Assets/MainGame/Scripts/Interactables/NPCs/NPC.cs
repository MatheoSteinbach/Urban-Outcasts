using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [Header("Cameras")]
    [SerializeField] GameObject minigameCam;
    [SerializeField] CinemachineVirtualCamera zoomCam;

    [SerializeField] string prompt;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public string InteractionPrompt => prompt;
    public bool CanInteract => canInteract;

    private bool canInteract;

    private void Start()
    {
        canInteract = true;
    }
    private void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            ZoomCamTurnOn();
        }
        else ZoomCamTurnOff();
    }
    public bool Interact(Interactor interactor)
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
        //minigameCam.SetActive(true);

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
}
 