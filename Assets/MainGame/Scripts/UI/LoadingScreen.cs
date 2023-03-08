using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image loadingBarFill;
    [SerializeField] Slider slider;
    [SerializeField] int sceneId;

    private void Start()
    {
        LoadScene(sceneId);
    }

    public void LoadScene(int _sceneId)
    {
        StartCoroutine(LoadSceneAsync(_sceneId));
    }

    IEnumerator LoadSceneAsync(int _sceneId)
    {
        yield return new WaitForSeconds(2);
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneId);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progressValue;

            yield return null;
        }
        
    }
}
