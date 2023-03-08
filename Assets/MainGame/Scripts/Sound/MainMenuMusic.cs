using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic Instance;

    [SerializeField] AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        if(currentScene.name == "MainMenu")
        {
            if(!musicSource.isPlaying)
            {
                musicSource.Play();

            }
        }
        if(currentScene.name == "IntroScene")
        {
            Destroy(gameObject);
        }
        
    }
}
