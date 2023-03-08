using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTutorial : MonoBehaviour
{
    private bool mFaded = false;

    public GameObject Canvas;

    private bool loadingStarted = false;

    public float Duration = 0.4f;

    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();

        // Toggle the end Value depending on the faded state
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));
        // Toggle the faded state
        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter/ Duration);

            yield return null;
        }
    }

    public void DeleteFade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));
        //Canvas.SetActive(false);
    }
}
