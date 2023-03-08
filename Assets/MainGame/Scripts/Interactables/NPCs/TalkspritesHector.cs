using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TalkspritesHector : MonoBehaviour
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
    private bool isHectorTalking;

    private void Start()
    {
        mood = TalkspriteMood.none;
        moodString = "none";
        isHectorTalking = false;
}

    private void Update()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (isHectorTalking)
            {
                dialogueNameText.text = dialogueName;
            }
            else if(!isHectorTalking)
            {
                dialogueNameText.text = dialoguePlayerName;
            }
        }

        moodString = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("moodStringHector")).value;
        mood = (TalkspriteMood)System.Enum.Parse(typeof(TalkspriteMood), moodString);

        isHectorTalking = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("isHectorTalking")).value;
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
                if (isHectorTalking)
                {
                    DisableSilhouettes();

                    talkspriteNeutral.gameObject.SetActive(true);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(false);
                }
                else
                {
                    NeutralSilhouette.gameObject.SetActive(true);
                    HappySilhouette.gameObject.SetActive(false);
                    AngrySilhouette.gameObject.SetActive(false);
                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(false);

                }
                break;

            case TalkspriteMood.Happy:
                if (isHectorTalking)
                {
                    DisableSilhouettes();

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(true);
                    talkspriteAngry.gameObject.SetActive(false);
                }
                else
                {
                    HappySilhouette.gameObject.SetActive(true);
                    NeutralSilhouette.gameObject.SetActive(false);
                    AngrySilhouette.gameObject.SetActive(false);

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(false);
                }
                break;

            case TalkspriteMood.Angry:
                if (isHectorTalking)
                {
                    DisableSilhouettes();

                    talkspriteAngry.gameObject.SetActive(true);
                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                }
                else
                {
                    AngrySilhouette.gameObject.SetActive(true);
                    HappySilhouette.gameObject.SetActive(false);
                    NeutralSilhouette.gameObject.SetActive(false);

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
        DialogueManager.GetInstance().SetVariableState("moodStringHector", obj);
    }
    public void SetMoodNeutral()
    {
        moodString = "Neutral";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringHector", obj);
    }
    public void SetMoodHappy()
    {
        moodString = "Happy";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringHector", obj);
    }
    public void SetMoodAngry()
    {
        moodString = "Angry";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringHector", obj);
    }
    public void SetMoodSad()
    {
        moodString = "Sad";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringHector", obj);
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
