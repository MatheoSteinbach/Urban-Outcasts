using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private ItemData item;

    private bool questItemOne;
    private bool hasGivenAncientPowerCore;
    private bool hasGivenNanalinsBracelet;
    private bool hasGivenEnergyStone;

    private void Update()
    {
        if (!hasGivenAncientPowerCore && item.Id == 1)
        {
            hasGivenAncientPowerCore = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("HectorCheckpoint2")).value;
            if (hasGivenAncientPowerCore)
            {
                Remove();
            }
        }
        if (item.Id == 2)
        {
            hasGivenNanalinsBracelet = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("NanalinCheckpoint2")).value;
            if (hasGivenNanalinsBracelet)
            {
                Remove();
            }
        }
        if (item.Id == 3)
        {
            hasGivenEnergyStone = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("moveGhostToPosition2")).value;
            if (hasGivenEnergyStone)
            {
                Remove();
            }
        }
       

        //if (questItemOne && item.Id == 1)
        //{
        //    questItemOne = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("hasGivenQuest1Item")).value;
        //    Remove();
        //}
    }
    
    public void Remove()
    {
        InventoryManager.Instance.RemoveItem(item);
        gameObject.SetActive(false);
    }
    public void Add(ItemData newItem)
    {
        item = newItem;
    }

    
}

