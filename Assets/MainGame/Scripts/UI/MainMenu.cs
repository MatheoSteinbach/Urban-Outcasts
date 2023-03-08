using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup shadow;
    // set Menu on Monobehaviour and add the button for first selected
    [Header("Menu Navigation")]
    [SerializeField] SaveSlotsMenu saveSlotsMenu;

    [Header("Mene Buttons")]
    [SerializeField] Button newGameButton;

    [SerializeField] Button continueGameButton;

    [SerializeField] Button loadGameButton;

    [SerializeField] Button settingsButton;

    private void Start()
    {
        //if (!DataPersistenceManager.instance.HasGameData())
        //{
        //    continueGameButton.interactable = false;
        //    loadGameButton.interactable = false;
        //}
        //else
        
            continueGameButton.interactable = false;
            loadGameButton.interactable = false;
        
    }

    public void OnNewGameClicked()
    {
        saveSlotsMenu.ActivateMenu(false);
        this.DeactivateMenu();
        shadow.alpha = 0;
    }
    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        this.DeactivateMenu();
    }
    public void OnContinueGameClicked()
    {
        DisableMenuButtons();
        //DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene(4);
    }
    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continueGameButton.interactable = false;
    }
    public void OnExitGameClicked()
    {
        Application.Quit();
    }
    public void OnSettingsClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
