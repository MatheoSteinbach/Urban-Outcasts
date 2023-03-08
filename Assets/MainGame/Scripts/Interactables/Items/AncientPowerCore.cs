using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientPowerCore : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource pickUpSound;
    [SerializeField] string prompt;
    [SerializeField] ItemData itemData;
    [SerializeField] PlayerController playerController;
    [SerializeField] PhoneUI phone;
    public string InteractionPrompt => prompt;
    private bool hasAncientPowerCore;
    public bool CanInteract => canInteract;

    private bool canInteract;

    private void Start()
    {
        canInteract = true;
        hasAncientPowerCore = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("hasAncientPowerCore")).value;

    }
   
    public bool Interact(Interactor interactor)
    {
        pickUpSound.Play();
        hasAncientPowerCore = true;
        phone.ActivateToggleBlink();
        InventoryManager.Instance.AddItem(itemData);
        Ink.Runtime.Object obj = new Ink.Runtime.BoolValue(hasAncientPowerCore);
        DialogueManager.GetInstance().SetVariableState("hasAncientPowerCore", obj);

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
