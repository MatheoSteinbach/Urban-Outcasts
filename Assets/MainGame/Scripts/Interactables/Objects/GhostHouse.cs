using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHouse : MonoBehaviour
{
    [SerializeField] DialogueObject ghostHouse;
    [SerializeField] GhostNPC ghost;

    private bool nanalinCheckpoint;
    private bool moveGhostToPosition2;
    private bool canGhostInteract;
    private void Start()
    {
        canGhostInteract = false;
        ghost.SetToCanNotInteract();
        nanalinCheckpoint = false;
        moveGhostToPosition2 = false;
    }

    private void Update()
    {
        if (!canGhostInteract)
        {
            canGhostInteract = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("canGhostInteract")).value;
            if (canGhostInteract)
            {
                ghost.SetToCanInteract();
                
            }
        }
        if (nanalinCheckpoint && !moveGhostToPosition2)
        {
            moveGhostToPosition2 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("moveGhostToPosition2")).value;
            if(moveGhostToPosition2)
            {
                ghostHouse.gameObject.SetActive(false);
            }
        }
        if (!nanalinCheckpoint)
        {
            ghostHouse.SetToCanNotInteract();
            nanalinCheckpoint = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("NanalinCheckpoint1")).value;
            if (nanalinCheckpoint)
            {
                ghostHouse.SetToCanInteract();
            }
        }
        

    }
}
