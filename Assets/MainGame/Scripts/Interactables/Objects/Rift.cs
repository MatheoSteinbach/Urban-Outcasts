using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rift : MonoBehaviour, IInteractable
{
    [Header("Interaction Prompt")]
    [SerializeField] string prompt;

    [SerializeField] PlayerDialogue playerDialogue;

    [SerializeField] GameObject arrow;
    public string InteractionPrompt => prompt;

    public bool CanInteract => canInteract;

    private bool canInteract;
    private bool riftMonologue;

    private void Start()
    {
        canInteract = true;
        riftMonologue = false;
    }
    
    public bool Interact(Interactor interactor)
    {
        riftMonologue = true;
        arrow.SetActive(false);
        Ink.Runtime.Object obj = new Ink.Runtime.BoolValue(riftMonologue);
        DialogueManager.GetInstance().SetVariableState("RiftMonologue", obj);
        playerDialogue.EnterDialogue();
        canInteract = false;
        return true;
    }
}
