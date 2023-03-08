using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [Header("TutorialManager")]
    [SerializeField] TutorialManager tutorialManager;

    [Header("Missions")]
    [SerializeField] GameObject mission1;
    [SerializeField] GameObject mission2;
    [SerializeField] GameObject mission3;
    [SerializeField] GameObject mission4;
    [SerializeField] GameObject mission5;
    [SerializeField] GameObject mission6;
    [SerializeField] GameObject mission7;

    [Header("Blockade")]
    [SerializeField] GameObject blockade1;


    private bool mission1Complete = false;
    private bool mission2Complete = false;
    private bool mission3Complete = false;
    private bool mission4Complete = false;
    private bool mission5Complete = false;
    private bool mission6Complete = false;
    private bool mission7Complete = false;


    private bool showPhoneQuest;
    private bool getPhoneQuest;
    private bool hectorCheckpoint1;
    private bool hectorCheckpoint2;
    private bool nanalinCheckpoint1;
    private bool hasNanalinsBracelet;
    private bool ghostCheckpoint1;
    private bool ghostCheckpoint2;
    private void Start()
    {
        mission1.GetComponentInChildren<Toggle>().isOn = false;
        mission2.GetComponentInChildren<Toggle>().isOn = false;
        mission3.GetComponentInChildren<Toggle>().isOn = false;
        mission4.GetComponentInChildren<Toggle>().isOn = false;
        mission5.GetComponentInChildren<Toggle>().isOn = false;
        mission6.GetComponentInChildren<Toggle>().isOn = false;
        mission7.GetComponentInChildren<Toggle>().isOn = false;
    }

    private void Update()
    {
        CheckForMission1();
        if (mission1Complete) { CheckForMission2(); }
        if (mission2Complete) { CheckForMission3(); }
        if (mission3Complete) { CheckForMission4(); }
        if (mission4Complete) { CheckForMission5(); }
        if (mission4Complete) { CheckForMission6(); }
        if (mission6Complete) { CheckForMission7(); }
    }

    private void CheckForMission1()
    {
        if (getPhoneQuest && showPhoneQuest)
        {
            Debug.Log("Show Quest 1 & 2");
            mission1.SetActive(true);
            mission2.SetActive(true);
            Mission1Complete();
            tutorialManager.PhoneControlsFadeIn();
            blockade1.SetActive(false);
            showPhoneQuest = false;
        }
        if (!getPhoneQuest && showPhoneQuest)
        {
            getPhoneQuest = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("getPhoneQuest")).value;

        }
    }
    private void CheckForMission2()
    {
        if (hectorCheckpoint1 && !mission2Complete)
        {
            Debug.Log("Show Quest 3");
            mission3.SetActive(true);
            Mission2Complete();
        }
        if (!hectorCheckpoint1)
        {
            hectorCheckpoint1 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("HectorCheckpoint1")).value;

        }
    }
    private void CheckForMission3()
    {
        if (hectorCheckpoint2 && !mission3Complete)
        {
            Debug.Log("Show Quest 4");
            mission4.SetActive(true);
            Mission3Complete();
        }
        if (!hectorCheckpoint2)
        {
            hectorCheckpoint2 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("HectorCheckpoint2")).value;

        }
    }

    private void CheckForMission4()
    {
        if (nanalinCheckpoint1 && !mission4Complete)
        {
            mission5.SetActive(true);
            mission6.SetActive(true);
            Mission4Complete();
        }
        if (!nanalinCheckpoint1)
        {
            nanalinCheckpoint1 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("NanalinCheckpoint1")).value;

        }
    }
    private void CheckForMission5()
    {
        if (hasNanalinsBracelet && !mission5Complete)
        {
            Mission5Complete();
        }
        if (!hasNanalinsBracelet)
        {
            hasNanalinsBracelet = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("NanalinCheckpoint2")).value;

        }
    }
    private void CheckForMission6()
    {
        if (ghostCheckpoint1 && !mission6Complete)
        {
            mission7.SetActive(true);
            Mission6Complete();
        }
        if (!ghostCheckpoint1)
        {
            ghostCheckpoint1 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("GhostCheckpoint1")).value;

        }
    }
    private void CheckForMission7()
    {
        if (ghostCheckpoint2 && !mission7Complete)
        {
            Mission7Complete();
        }
        if (!ghostCheckpoint2)
        {
            ghostCheckpoint2 = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("GhostCheckpoint2")).value;

        }
    }

    public void ToggleCompletedMissions()
    {
        if (mission1Complete) 
        {
            if (mission1.activeSelf)
            {
                mission1.SetActive(false);
            }
            else if(!mission1.activeSelf)
            {
                mission1.SetActive(true);
            }
        }
    }


    public void ShowPhoneQuest()
    {
        showPhoneQuest = true;
    }
    public void Mission1Complete()
    {
        mission1Complete = true;
        mission1.GetComponentInChildren<Toggle>().isOn = true;
    }
    public void Mission2Complete()
    {
        mission2Complete = true;
        mission2.GetComponentInChildren<Toggle>().isOn = true;
    }
    public void Mission3Complete()
    {
        mission3Complete = true;
        mission3.GetComponentInChildren<Toggle>().isOn = true;
    }
    public void Mission4Complete()
    {
        mission4Complete = true;
        mission4.GetComponentInChildren<Toggle>().isOn = true;
    }
    public void Mission5Complete()
    {
        mission5Complete = true;
        mission5.GetComponentInChildren<Toggle>().isOn = true;
    }
    public void Mission6Complete()
    {
        mission6Complete = true;
        mission6.GetComponentInChildren<Toggle>().isOn = true;
    }
    public void Mission7Complete()
    {
        mission7Complete = true;
        mission7.GetComponentInChildren<Toggle>().isOn = true;
    }
}
