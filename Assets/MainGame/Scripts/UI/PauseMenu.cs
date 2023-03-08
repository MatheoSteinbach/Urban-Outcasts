using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject settingsPanel;

    [SerializeField] PlayerController playerController;
    [SerializeField] PhoneUI phone;

    public void OnContinueClicked()
    {
        playerController.EnableMovement();
        gameObject.SetActive(false);
        phone.SetPauseOff();
    }
    public void OnNewGameClicked()
    {
        SceneManager.LoadScene(3);
    }

    public void OnSettingsClicked()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    public void OnBackClicked()
    {
        menuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void OnCreditsClicked()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void OnExitGameClicked()
    {
        SceneManager.LoadScene(0);
    }
}
