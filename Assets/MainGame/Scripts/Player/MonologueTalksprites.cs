using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class MonologueTalksprites : MonoBehaviour
{
    [Header("MonologueTalksprites")]
    [SerializeField] Image monoTalkspriteNeutral;
    [SerializeField] Image monoTalkspriteHappy;
    [SerializeField] Image monoTalkspriteAngry;


    private TalkspriteMood monologueMood;
    private string monologueMoodString = "";

    private bool isOnMonologue;

    private void Start()
    {
        monologueMood = TalkspriteMood.none;
        monologueMoodString = "none";
        isOnMonologue = false;
    }

    private void Update()
    {
        monologueMoodString = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("monologueMoodString")).value;
        monologueMood = (TalkspriteMood)System.Enum.Parse(typeof(TalkspriteMood), monologueMoodString);

        switch (monologueMood)
        {
            case TalkspriteMood.none:

                monoTalkspriteNeutral.gameObject.SetActive(false);
                monoTalkspriteHappy.gameObject.SetActive(false);
                monoTalkspriteAngry.gameObject.SetActive(false);

                break;

            case TalkspriteMood.Neutral:

                monoTalkspriteNeutral.gameObject.SetActive(true);
                monoTalkspriteHappy.gameObject.SetActive(false);
                monoTalkspriteAngry.gameObject.SetActive(false);


                break;

            case TalkspriteMood.Happy:

                monoTalkspriteNeutral.gameObject.SetActive(false);
                monoTalkspriteHappy.gameObject.SetActive(true);
                monoTalkspriteAngry.gameObject.SetActive(false);

                break;

            case TalkspriteMood.Angry:

                monoTalkspriteNeutral.gameObject.SetActive(false);
                monoTalkspriteHappy.gameObject.SetActive(false);
                monoTalkspriteAngry.gameObject.SetActive(true);

                break;
            default:
                break;
        }
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
