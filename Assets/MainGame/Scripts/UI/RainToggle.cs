using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RainToggle : MonoBehaviour
{
    public static RainToggle Instance;

    [SerializeField] Toggle rainToggle;

    private bool isToggleOn = false;
    private GameObject rainSystem;
    private bool isRaining = false;
    private bool getRainSystem = false;
    
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
    private void Start()
    {
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "SettingsMenu")
        {
            rainToggle = GameObject.FindGameObjectWithTag("RainToggle").GetComponent<Toggle>();
            isToggleOn = rainToggle.isOn;
            getRainSystem = false;
        }
        else if (sceneName == "Game")
        {
            if(!getRainSystem)
            {
                rainSystem = GameObject.FindGameObjectWithTag("RainSystem");
                getRainSystem = true;
                if (isToggleOn)
                {
                    rainSystem.gameObject.SetActive(true);
                }
                else
                {

                    rainSystem.gameObject.SetActive(false);

                }
            }




        }

    }
}
