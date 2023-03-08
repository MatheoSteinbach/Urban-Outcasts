using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkspritesGhost : MonoBehaviour
{
    [Header("Talksprites")]
    [SerializeField] Image talkspriteNeutral;
    [SerializeField] Image talkspriteHappy;
    [SerializeField] Image talkspriteAngry;
    [SerializeField] Image NeutralSilhouette;
    [SerializeField] Image HappySilhouette;
    [SerializeField] Image AngrySilhouette;

    [Header("Names")]
    [SerializeField] string dialogueName;
    [SerializeField] string dialoguePlayerName;

    [Header("Dialogue Name Text")]
    [SerializeField] TextMeshProUGUI dialogueNameText;

    private TalkspriteMood mood;
    private string moodString = "";
    private bool isGhostTalking;

    private void Start()
    {
        mood = TalkspriteMood.none;
        moodString = "none";
        isGhostTalking = false;
    }

    private void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (isGhostTalking)
            {
                dialogueNameText.text = dialogueName;
            }
            else if (!isGhostTalking)
            {
                dialogueNameText.text = dialoguePlayerName;
            }
        }

        moodString = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("moodStringGhost")).value;
        mood = (TalkspriteMood)System.Enum.Parse(typeof(TalkspriteMood), moodString);

        isGhostTalking = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("isGhostTalking")).value;
        // GET MOOD FROM INK
        //switch (string)
        //neutral, happy, etc.
        ////////////////
        switch (mood)
        {
            case TalkspriteMood.none:
                // Hector
                talkspriteNeutral.gameObject.SetActive(false);
                talkspriteHappy.gameObject.SetActive(false);
                talkspriteAngry.gameObject.SetActive(false);
                DisableSilhouettes();

                break;

            case TalkspriteMood.Neutral:
                if (isGhostTalking)
                {
                    DisableSilhouettes();

                    talkspriteNeutral.gameObject.SetActive(true);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(false);
                }
                else
                {
                    NeutralSilhouette.gameObject.SetActive(true);

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(false);

                }
                break;

            case TalkspriteMood.Happy:
                if (isGhostTalking)
                {
                    DisableSilhouettes();

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(true);
                    talkspriteAngry.gameObject.SetActive(false);
                }
                else
                {
                    HappySilhouette.gameObject.SetActive(true);

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(false);
                }
                break;

            case TalkspriteMood.Angry:
                if (isGhostTalking)
                {
                    DisableSilhouettes();

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(true);
                }
                else
                {
                    AngrySilhouette.gameObject.SetActive(true);

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
    private void DisableSilhouettes()
    {
        NeutralSilhouette.gameObject.SetActive(false);
        HappySilhouette.gameObject.SetActive(false);
        AngrySilhouette.gameObject.SetActive(false);
    }
    public void SetMoodNone()
    {
        moodString = "none";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringGhost", obj);
    }
    public void SetMoodNeutral()
    {
        moodString = "Neutral";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringGhost", obj);
    }
    public void SetMoodHappy()
    {
        moodString = "Happy";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringGhost", obj);
    }
    public void SetMoodAngry()
    {
        moodString = "Angry";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringGhost", obj);
    }
    public void SetMoodSad()
    {
        moodString = "Sad";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringGhost", obj);
    }

    public void ActivateSelf()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
