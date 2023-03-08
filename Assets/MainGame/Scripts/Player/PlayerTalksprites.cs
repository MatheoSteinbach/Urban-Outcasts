using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerTalksprites : MonoBehaviour
{
    [Header("Talksprites")]
    [SerializeField] Image talkspriteNeutral;
    [SerializeField] Image talkspriteHappy;
    [SerializeField] Image talkspriteAngry;
    [SerializeField] Image NeutralSilhouette;
    [SerializeField] Image HappySilhouette;
    [SerializeField] Image AngrySilhouette;

    private TalkspriteMood mood;
    private string moodString = "";

    private bool isHectorTalking;
    private bool isEdithTalking;
    private bool isNanalinTalking;
    private bool isGhostTalking;
    private void Start()
    {
        mood = TalkspriteMood.none;
        moodString = "none";
        isHectorTalking = false;
        isEdithTalking = false;
        isNanalinTalking = false;
        isGhostTalking = false;
    }

    private void Update()
    {
        moodString = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("moodStringPlayer")).value;
        mood = (TalkspriteMood)System.Enum.Parse(typeof(TalkspriteMood), moodString);

        isHectorTalking = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("isHectorTalking")).value;
        isEdithTalking = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("isEdithTalking")).value;
        isNanalinTalking = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("isNanalinTalking")).value;
        isGhostTalking = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("isGhostTalking")).value;

        // GET MOOD FROM INK
        //switch (string)
        //neutral, happy, etc.
        ////////////////
        switch (mood)
        {
            case TalkspriteMood.none:

                talkspriteNeutral.gameObject.SetActive(false);
                talkspriteHappy.gameObject.SetActive(false);
                talkspriteAngry.gameObject.SetActive(false);
                DisableSilhouettes();

                break;

            case TalkspriteMood.Neutral:
                if (!isHectorTalking && !isEdithTalking && !isNanalinTalking && !isGhostTalking)
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
                if (!isHectorTalking && !isEdithTalking && !isNanalinTalking && !isGhostTalking)
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
                if (!isHectorTalking && !isEdithTalking && !isNanalinTalking && !isGhostTalking)
                {
                    DisableSilhouettes();

                    talkspriteNeutral.gameObject.SetActive(false);
                    talkspriteHappy.gameObject.SetActive(false);
                    talkspriteAngry.gameObject.SetActive(true);
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
    public void ActivateSelf()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}




