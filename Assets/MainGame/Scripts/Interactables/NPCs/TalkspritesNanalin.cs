using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkspritesNanalin : MonoBehaviour
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
    private bool isNanalinTalking;

    private void Start()
    {
        mood = TalkspriteMood.none;
        moodString = "none";
        isNanalinTalking = false;
    }

    private void Update()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (isNanalinTalking)
            {
                dialogueNameText.text = dialogueName;
            }
            else if (!isNanalinTalking)
            {
                dialogueNameText.text = dialoguePlayerName;
            }
        }

        moodString = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("moodStringNanalin")).value;
        mood = (TalkspriteMood)System.Enum.Parse(typeof(TalkspriteMood), moodString);

        isNanalinTalking = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("isNanalinTalking")).value;
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
                if (isNanalinTalking)
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
                if (isNanalinTalking)
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
                if (isNanalinTalking)
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
        DialogueManager.GetInstance().SetVariableState("moodStringNanalin", obj);
    }
    public void SetMoodNeutral()
    {
        moodString = "Neutral";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringNanalin", obj);
    }
    public void SetMoodHappy()
    {
        moodString = "Happy";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringNanalin", obj);
    }
    public void SetMoodAngry()
    {
        moodString = "Angry";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringNanalin", obj);
    }
    public void SetMoodSad()
    {
        moodString = "Sad";
        Ink.Runtime.Object obj = new Ink.Runtime.StringValue(moodString);
        DialogueManager.GetInstance().SetVariableState("moodStringNanalin", obj);
    }

    public void ActivateSelf()
    {
        gameObject.SetActive(true);
        //StartCoroutine(DoFade(canvasGroup));
    }
    public void DeactivateSelf()
    {
        gameObject.SetActive(false);

    }
    private IEnumerator DoFade(CanvasGroup canvGroup)
    {
        while(canvGroup.alpha <= 0.99f)
        {
            canvGroup.alpha += 0.1f;
        }
        
        yield return null;
    }
}
