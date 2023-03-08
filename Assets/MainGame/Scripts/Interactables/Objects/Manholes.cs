using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manholes : MonoBehaviour
{
    [SerializeField] DialogueObject manhole1;
    [SerializeField] DialogueObject manhole2;
    [SerializeField] DialogueObject manhole3;

    private bool hectorCheckpoint2;
    private bool manholeCanInteract;
    private bool moveNanalinToPosition2;
    private void Start()
    {
        hectorCheckpoint2 = false;
        moveNanalinToPosition2 = false;
    }
    private void Update()
    {
        if(hectorCheckpoint2 && !moveNanalinToPosition2)
        {
            moveNanalinToPosition2 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("moveNanalinToPosition2")).value;
            if (moveNanalinToPosition2)
            {
                DeActivateManholes();
            }
        }
        if(!hectorCheckpoint2)
        {
            SetManholesCanNotInteract();
            hectorCheckpoint2 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("HectorCheckpoint2")).value;
            if(hectorCheckpoint2)
            {
                SetManholesCanInteract();
            }
        }

    }
    public void SetManholesCanInteract()
    {
        manhole1.SetToCanInteract();
        manhole2.SetToCanInteract();
        manhole3.SetToCanInteract();
    }
    public void SetManholesCanNotInteract()
    {
        manhole1.SetToCanNotInteract();
        manhole2.SetToCanNotInteract();
        manhole3.SetToCanNotInteract();
    }
    public void DeActivateManholes()
    {
        manhole1.ZoomCamTurnOff();
        manhole1.gameObject.SetActive(false);
        manhole2.gameObject.SetActive(false);
        manhole3.gameObject.SetActive(false);
    }


}
