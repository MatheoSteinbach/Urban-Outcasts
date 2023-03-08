using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStone : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource pickUpSound;
    [SerializeField] string prompt;
    [SerializeField] ItemData itemData;
    [SerializeField] PlayerController playerController;
    [SerializeField] PhoneUI phone;
    public string InteractionPrompt => prompt;
    private bool hasEnergyStone;
    //private bool hasQuestItem;
    public bool CanInteract => canInteract;

    private bool canInteract;

    private void Start()
    {
        canInteract = true;
        hasEnergyStone = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("hasEnergyStone")).value;

        //hasQuestItem = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("hasQuest1Item")).value;
    }
    private void Update()
    {

    }
    public bool Interact(Interactor interactor)
    {
        pickUpSound.Play();
        hasEnergyStone = true;
        phone.ActivateToggleBlink();
        InventoryManager.Instance.AddItem(itemData);
        Ink.Runtime.Object obj = new Ink.Runtime.BoolValue(hasEnergyStone);
        DialogueManager.GetInstance().SetVariableState("hasEnergyStone", obj);

        //Ink.Runtime.Object obj2 = new Ink.Runtime.BoolValue(hasQuestItem = true);
        //DialogueManager.GetInstance().SetVariableState("hasQuest1Item", obj2);

        StartCoroutine(itemPickedUp());
        //Destroy(gameObject);
        return true;
    }
    IEnumerator itemPickedUp()
    {
        yield return new WaitForSeconds(0.35f);
        playerController.EnableMovement();
        gameObject.SetActive(false);
    }
}

