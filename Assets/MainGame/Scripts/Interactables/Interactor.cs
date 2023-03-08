using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    [SerializeField] private int numFound;

    private PlayerController playerController;

    private readonly Collider[] colliders = new Collider[3];
    private IInteractable interactable;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
        if (numFound > 0 & !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null && interactable.CanInteract)
            {
                if (!interactionPromptUI.isDisplayed) 
                { 
                    interactionPromptUI.SetUp(interactable.InteractionPrompt); 
                }

                if (Keyboard.current.eKey.wasPressedThisFrame) 
                {
                    interactable.Interact(this);
                    interactionPromptUI.Close();
                }
            }
        }
        else
        {
            if (interactable != null) 
            { 
                interactable = null; 
            }
            if (interactionPromptUI.isDisplayed)
            {
                interactionPromptUI.Close();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
}
