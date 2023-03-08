using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour, IInteractable
{
    [SerializeField] string prompt;
    [SerializeField] ItemData itemData;
    public string InteractionPrompt => prompt;
    private bool hasHammer;
    private bool hasQuestItem;
    public bool CanInteract => canInteract;

    private bool canInteract;

    private void Start()
    {
        canInteract = true;

        hasHammer = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("hasHammer")).value;

        hasQuestItem = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("hasQuest1Item")).value;
    }
    public bool Interact(Interactor interactor)
    {
        InventoryManager.Instance.AddItem(itemData);
        hasHammer = true;
        hasQuestItem = true;
        Ink.Runtime.Object obj = new Ink.Runtime.BoolValue(hasHammer);
        DialogueManager.GetInstance().SetVariableState("hasHammer", obj);

        Ink.Runtime.Object obj2 = new Ink.Runtime.BoolValue(hasQuestItem);
        DialogueManager.GetInstance().SetVariableState("hasQuest1Item", obj2);

        gameObject.SetActive(false);
        //Destroy(gameObject);
        return true;
    }
}
