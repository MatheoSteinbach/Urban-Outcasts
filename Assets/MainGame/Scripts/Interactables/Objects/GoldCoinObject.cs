using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoinObject : MonoBehaviour, IInteractable
{
    [Header("Coins")]
    [SerializeField] Coins coins;
    [SerializeField] int amount;

    [Header("Interaction")]
    [SerializeField] string prompt;
    [SerializeField] ItemData itemData;
    [SerializeField] Animator arrowAnimator;
    
    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    public string InteractionPrompt => prompt;
    public bool CanInteract => canInteract;

    private bool canInteract;
    private void Start()
    {
        canInteract = true;
    }
    public bool Interact(Interactor interactor)
    {
        if(canInteract)
        {
            //InventoryManager.Instance.AddItem(itemData);
            audioSource.Play();
            coins.AddCoin(amount);
            canInteract = false;
            arrowAnimator.gameObject.SetActive(false);
        }
        return true;
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
