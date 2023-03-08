using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Goldbag")]
    [SerializeField] GameObject goldbag;
    [Header("Player")]
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerDialogue playerDialogue;

    [Header("Canvas Groups")]
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] CanvasGroup canvasGroupPhone;
    
    [Header("Tutorial Panel")]
    [SerializeField] GameObject tutorialPanel;

    [Header("Tutorial Controls")]
    [SerializeField] GameObject controls;
    [SerializeField] GameObject phoneControls;
    
    [SerializeField] float Duration = 0.4f;
    
    private bool mFaded = true;
    private bool showControls = false;
    private bool showPhoneControls = false;

    //private bool loadingStarted = false;


    private void Start()
    {
        ControlsFadeIn();
    }
    public void ControlsFadeIn()
    {
        tutorialPanel.SetActive(true);
        controls.SetActive(true);
        
        playerController.DisableMovement();

        //var canvGroup = GetComponent<CanvasGroup>();

        // Toggle the end Value depending on the faded state
        StartCoroutine(DoFade(canvasGroup, canvasGroup.alpha, mFaded ? 1 : 0));
        // Toggle the faded state
        mFaded = !mFaded;
    }


    public void ControlsDeleteFade()
    {
        playerController.EnableMovement();
        goldbag.SetActive(true);
        //var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFadeOut(canvasGroup, canvasGroup.alpha, mFaded ? 1 : 0));
        //Canvas.SetActive(false);
        playerDialogue.EnterDialogue();
        mFaded = !mFaded;
        //controls.SetActive(false);
    }

    public void PhoneControlsFadeIn()
    {
        tutorialPanel.SetActive(true);
        phoneControls.SetActive(true);

        playerController.DisableMovement();

        //var canvGroup = GetComponent<CanvasGroup>();

        // Toggle the end Value depending on the faded state
        StartCoroutine(DoFade(canvasGroupPhone, canvasGroupPhone.alpha, mFaded ? 1 : 0));
        // Toggle the faded state
        mFaded = !mFaded;
    }

    public void PhoneControlsDeleteFade()
    {
        playerController.EnableMovement();

        //var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFadeOut(canvasGroupPhone, canvasGroupPhone.alpha, mFaded ? 1 : 0));
        //Canvas.SetActive(false);
        mFaded = !mFaded;
        //controls.SetActive(false);
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }

    public IEnumerator DoFadeOut(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
        controls.SetActive(false);
        phoneControls.SetActive(false);
        tutorialPanel.SetActive(false);
    }
}